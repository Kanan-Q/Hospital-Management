﻿using HospitalManagement.BL.DTO;
using HospitalManagement.BL.DTO.Patient;
using HospitalManagement.Core.Entities;
using HospitalManagement.Core.Enum;
using HospitalManagement.Core.Repositories;
using HospitalManagement.DataAccess.Context;
using HospitalManagement.DataAccess.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Security.Claims;

namespace HospitalManagement.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PatientController(IPatientRepository _repo, AppDbContext _sql, IPatientAccountRepository _r) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> AllPatients()
        {
            var patients = await _repo.AllAsync(User);
            var dto = patients.Select(x => new
            {
                x.Id,
                x.Name,
                x.Surname,
                x.Age,
                x.Email,
                x.Count,
                x.CreatedTime,
                x.FIN,
                x.Phone,
                x.Series,
                x.Gender,
                x.BirthDay,
                x.Address,
                Prescription = x.Prescriptions.Select(x => new { x.Doctor.Name, x.MedicationName}).ToList(),
                Doctors = x.DoctorPatients.Select(y => new { y.Doctor.Name, y.Doctor.Surname }).ToList()

            }).ToList();
            return Ok(dto);
        }
        [HttpGet]
        public async Task<IActionResult> Search([FromQuery] string query) => Ok(await _repo.SearchAsync(query, User));

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(PatientCreateDTO dto)
        {
            Patient patient = new Patient()
            {
                Name = dto.Name,
                Surname = dto.Surname,
                Age = dto.Age,
                Email = dto.Email,
                FIN = dto.FIN,
                Phone=dto.Phone,
                Gender=(Gender)dto.Gender,
                BirthDay=dto.BirthDay,
                Series = dto.Series,
                Address = dto.Address,
            };
            await _repo.AddAsync(patient);

            foreach (var item in dto.DoctorId)
            {
                DoctorPatient doctorPatient = new DoctorPatient()
                {
                    DoctorId = item,
                    PatientId = patient.Id,
                };
                await _sql.DoctorPatients.AddAsync(doctorPatient);
            }
            await _sql.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var patient = await _repo.GetByIdAsync(id);
            await _repo.DeleteAsync(patient);
            return Ok();
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, PatientUpdateDTO dto)
        {
            var patient = await _repo.GetByIdAsync(id);
            patient.Name = dto.Name;
            patient.Surname = dto.Surname;
            patient.Age = dto.Age;
            patient.Email = dto.Email;
            patient.FIN = dto.FIN;
            patient.Series = dto.Series;
            patient.Phone = dto.Phone;
            patient.BirthDay = dto.BirthDay;
            patient.Gender = (Gender)dto.Gender;
            patient.Address = dto.Address;
            await _repo.UpdateAsync(patient);
            return Ok();
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) => Ok(await _repo.GetByIdAsync(id));

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatientByIdForDoctor(int id)
        {
            var userEmail = User.FindFirst(ClaimTypes.Name)?.Value;

            if (string.IsNullOrEmpty(userEmail))
            {
                return Unauthorized("İstifadəçi məlumatı tapılmadı.");
            }

            var patient = await _repo.GetByIdForDoctorAsync(id, User);
            if (patient == null)
            {
                return NotFound("Xəstə tapılmadı.");
            }

            return Ok(patient);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePrescription([FromBody] PrescriptionCreateDTO dto)
        {
            var doctorId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var doctor = await _sql.Doctors.FindAsync(doctorId);
            var patient = await _sql.Patients.FindAsync(dto.PatientId);
            if (patient == null) return BadRequest(new { message = "Patient not found." });

            var prescription = new Prescription
            {
                DoctorId = doctorId,
                PatientId = dto.PatientId,
                MedicationName = dto.MedicationName,
            };

            await _sql.Prescriptions.AddAsync(prescription);
            await _sql.SaveChangesAsync();

            return Ok(new Prescription
            {
                DoctorId = doctor.Id,
                MedicationName = dto.MedicationName,
                PatientId = dto.PatientId,
            });
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePrescription(int id, [FromBody] PrescriptionUpdateDTO dto)
        {
            var doctorId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            var prescription = await _sql.Prescriptions
                .FirstOrDefaultAsync(p => p.PatientId == id && p.DoctorId == doctorId);

            if (prescription == null)
                return NotFound(new { message = "Prescription not found or not authorized." });

            if (!string.IsNullOrWhiteSpace(dto.MedicationName))
                prescription.MedicationName = dto.MedicationName;


            await _sql.SaveChangesAsync();

            return Ok(new
            {
                DoctorId = prescription.DoctorId,
                PatientId = prescription.PatientId,
                MedicationName = prescription.MedicationName,
            });
        }


        [HttpGet]
        public async Task<IActionResult> MyInfo()
        {
            var user = HttpContext.User;

            var Name = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
            var finCode = user.Claims.FirstOrDefault(c => c.Type == "FinCode")?.Value;

            if (finCode == null || Name == null)
            {
                return Unauthorized("Invalid token");
            }

            var patient = await _repo.GetByFinCodeAsync(finCode);

            if (patient == null || patient.Name != Name)
            {
                return NotFound("Patient not found or data mismatch");
            }

            return Ok(new
            {
                Id=patient.Id,
                Name = patient.Name,
                FinCode = patient.FIN,
                Surname = patient.Surname,
                Email = patient.Email,
                Series = patient.Series,
                Phone=patient.Phone,
                Age = patient.Age,
                receipt = patient.Prescriptions.Select(x => new
                {
                    DoctorName = x.Doctor.Name,
                    Medication = x.MedicationName
                })
                .ToList(),
            });
        }
        [HttpGet]
        public async Task<IActionResult> GetPatientByGender(int gender) => Ok(await _repo.GetPatientsByGenderAsync(gender));
        //[HttpGet]
        //public async Task<IActionResult> GetPatientByDepartment(string department) => Ok(await _repo.GetPatientsByDepartmentAsync(department));
    }
}

