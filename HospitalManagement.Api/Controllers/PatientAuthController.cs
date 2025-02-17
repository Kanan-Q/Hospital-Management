using HospitalManagement.BL.DTO.PatientAccount;
using HospitalManagement.BL.Helper;
using HospitalManagement.Core.Entities;
using HospitalManagement.Core.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HospitalManagement.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PatientAuthController : ControllerBase
    {
        private readonly IPatientRepository _patientRepo;
        private readonly IPatientAccountRepository _patientAccountRepo;
        private readonly PatientJwtHelper _jwtHelper;

        public PatientAuthController(IPatientRepository patientRepo, IPatientAccountRepository patientAccountRepo, PatientJwtHelper jwtHelper)
        {
            _patientRepo = patientRepo;
            _patientAccountRepo = patientAccountRepo;
            _jwtHelper = jwtHelper;
        }

        // Şifrəni SHA-256 ilə hash etmək
        private string HashPassword(string password)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                var bytes = System.Text.Encoding.UTF8.GetBytes(password);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        // Şifrəni yoxlamaq (daxil edilən password ilə saxlanılan hash-i müqayisə edirik)
        private bool VerifyPassword(string password, string storedHash)
        {
            return HashPassword(password) == storedHash;
        }

        // Yeni istifadəçi qeydiyyatı (register)
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] PatientAccountRegisterDTO dto)
        {
            // Şifrəni SHA-256 ilə hash edirik
            var hashedPassword = HashPassword(dto.Password);

            // Yeni istifadəçi yaradılır
            var newAccount = new PatientAccount
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

            var token = _jwtHelper.GenerateToken(account.Name, account.FinCode);
            return Ok(new { Token = token });
        }
        [HttpGet]
        public async Task<IActionResult> MyInfo()
        {
            var user = HttpContext.User;

            var finCode = user.Claims.FirstOrDefault(c => c.Type == "FinCode")?.Value;
            var fullName = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;

            if (finCode == null || fullName == null)
            {
                return Unauthorized("Invalid token");
            }

            var patients = await _patientRepo.GetPatientWithReceiptsAsync(finCode);

            if (patients == null || !patients.Any())
            {
                return NotFound("Patient not found");
            }

            var patientInfo = new
            {
                FullName = fullName,
                FinCode = finCode,

                //Doctors = patients.SelectMany(x => x.DoctorPatients).Select(x => new
                //{
                //    DoctorName = x.Doctor.Name
                //}).ToList(),
                Receipts = patients.SelectMany(p => p.Prescriptions).Select(r => new
                    {
                        DoctorName = r.Doctor.Name,
                        Medication = r.MedicationName
                    })
                    .ToList()
            };

            return Ok(patientInfo);
        }
    }

}





