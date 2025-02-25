using HospitalManagement.BL.DTO.PatientAccount;
using HospitalManagement.BL.Helper;
using HospitalManagement.Core.Entities;
using HospitalManagement.Core.Repositories;
using HospitalManagement.DataAccess.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace HospitalManagement.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PatientAuthController(IPatientRepository _repo, IPatientAccountRepository _patientAccountRepo, PatientJwtHelper _jwtHelper, AppDbContext _sql) : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] PatientAccountRegisterDTO dto)
        {
            var hashedPassword = HashPassword(dto.Password);

            PatientAccount newAccount = new PatientAccount
            {
                Name = dto.Name,
                FinCode = dto.FIN,
                PasswordHash = hashedPassword
            };

            await _patientAccountRepo.AddAsync(newAccount);
            return Ok("Registration successful");
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] PatientAccountLoginDTO dto)
        {

            var account = await _patientAccountRepo.GetByFinCodeAsync(dto.FIN);

            if (account == null || !VerifyPassword(dto.Password, account.PasswordHash))
                return Unauthorized("Invalid credentials");

            var token = _jwtHelper.GenerateToken(account.FinCode);
            return Ok(new { Token = token });
        }

        [HttpGet]
        public async Task<IActionResult> MyInfo()
        {
            var user = HttpContext.User;

            //var Name = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
            var finCode = user.Claims.FirstOrDefault(c => c.Type == "FinCode")?.Value;

            if (finCode == null)
            {
                return Unauthorized("Invalid token");
            }

            var patient = await _repo.GetByFinCodeAsync(finCode);

            if (patient == null)
            {
                return NotFound("Patient not found or data mismatch");
            }
            var patientInfo = new
            {
                Name = patient.Name,
                Surname = patient.Surname,
                Age = patient.Age,
                FIN = patient.FIN,
                Email = patient.Email,
                Series = patient.Series,
                Address = patient.Address,
                receipt = patient.Prescriptions.Select(x => new
                {
                    DoctorName = x.Doctor.Name,
                    DoctorSurname = x.Doctor.Surname,
                    DoctorEmail = x.Doctor.Email,
                    DoctorDepartment = x.Doctor.Department.DepartmentName,
                    Medication = x.MedicationName,
                    Count=x.Doctor.Count,
                    Time = x.CreatedTime
                })
                .ToList(),

            };
            return Ok(patientInfo);
        }


        [HttpGet]
        public async Task<IActionResult> Search(string query) => Ok(await _patientAccountRepo.SearchAsync(query));


        private string HashPassword(string password)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                var bytes = System.Text.Encoding.UTF8.GetBytes(password);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        private bool VerifyPassword(string password, string storedHash)=>HashPassword(password) == storedHash;
        
    }
}





