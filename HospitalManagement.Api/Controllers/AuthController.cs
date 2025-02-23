using HospitalManagement.BL.DTO.Doctor;
using HospitalManagement.BL.SignalR;
using HospitalManagement.Core.Entities;
using HospitalManagement.Core.Enum;
using HospitalManagement.Core.Repositories;
using HospitalManagement.DataAccess.Context;
using HospitalManagement.DataAccess.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace HospitalManagement.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _sql;
        private readonly JwtHelper _jwtHelper;
        private readonly IDoctorRepository _repo;
        private readonly IHubContext<NotificationHub> _hubContext;

        public AuthController(AppDbContext sql, IDoctorRepository repo, IConfiguration configuration, IHubContext<NotificationHub> hubContext)
        {
            _sql = sql;
            _jwtHelper = new JwtHelper(configuration);
            _repo = repo;
            _hubContext = hubContext;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] DoctorLoginDTO model)
        {
            if (model.UsernameOrEmail == "admin@example.com" && model.Password == "adminpassword123")
            {
                var token = _jwtHelper.GenerateJwtToken(model.UsernameOrEmail, "Admin", 0);
                await _hubContext.Clients.All.SendAsync("UserStatusChanged", model.UsernameOrEmail);
                return Ok(new { Token = token });
            }

            var doctor = await _sql.Doctors.FirstOrDefaultAsync(d => d.Email == model.UsernameOrEmail || d.Name == model.UsernameOrEmail);
            if (doctor == null || !VerifyPassword(model.Password, doctor.PasswordHash))
            {
                return Unauthorized(new { message = "Invalid email or password." });
            }
            doctor.IsActive = true;
            await _sql.SaveChangesAsync();

            var tokenDoctor = _jwtHelper.GenerateJwtToken(doctor.Email, "Doctor", doctor.Id);
            await _hubContext.Clients.All.SendAsync("UserStatusChanged", doctor.Name);
            return Ok(new { Token = tokenDoctor });
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) => Ok(await _repo.GetByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] DoctorRegisterDTO model)
        {
            if (await _sql.Doctors.AnyAsync(d => d.Email == model.Email))
            {
                return BadRequest(new { message = "Email or Name already in use." });
            }

            Doctor doctor = new Doctor
            {
                Name = model.Name,
                Surname = model.Surname,
                Age = model.Age,
                Email = model.Email,
                FIN = model.FIN,
                Series = model.Series,
                Address = model.Address,
                Education = model.Education,
                DepartmentId = model.DepartmentId,
                PasswordHash = HashPassword(model.Password),
                Salary = model.Salary,
                Gender = (Gender)model.Gender,
                Birthday = model.Birthday,
                Phone = model.Phone,
            };

            await _sql.Doctors.AddAsync(doctor);
            await _sql.SaveChangesAsync();

            return Ok(new { message = "Doctor registered successfully." });
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized(new { message = "Token is missing." });
            }

            var principal = _jwtHelper.GetPrincipalFromExpiredToken(token);
            if (principal == null)
            {
                return Unauthorized(new { message = "Invalid token." });
            }

            var usernameOrEmail = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
            if (string.IsNullOrEmpty(usernameOrEmail))
            {
                return Unauthorized(new { message = "User not found in token." });
            }

            var doctor = await _sql.Doctors.FirstOrDefaultAsync(d => d.Email == usernameOrEmail || d.Name == usernameOrEmail);
            if (doctor == null)
            {
                return Unauthorized(new { message = "User not found in database." });
            }

            doctor.IsActive = false;
            await _sql.SaveChangesAsync();

            await _hubContext.Clients.All.SendAsync("UserStatusChanged", usernameOrEmail, false);
            return Ok(new { message = "User logged out successfully." });

        }


        [HttpGet]
        //[Authorize(Roles = "Doctor,Admin")]
        public async Task<IActionResult> MyInfo()
        {
            var userEmail = User.FindFirst(ClaimTypes.Name)?.Value;

            if (string.IsNullOrEmpty(userEmail))
            {
                return Unauthorized(new { message = "User not authenticated." });
            }

            var doctor = await _sql.Doctors.Include(x => x.Department).FirstOrDefaultAsync(d => d.Email == userEmail);

            if (doctor == null)
            {
                return NotFound(new { message = "Doctor not found." });
            }

            return Ok(new { doctor.Id, doctor.Name, doctor.Education,doctor.Birthday,doctor.Surname, doctor.Age, doctor.Phone, doctor.Salary, doctor.Email, doctor.FIN, doctor.Series, doctor.Address, doctor.Department.DepartmentName, doctor.CreatedTime });
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Search([FromQuery] string query) => Ok(await _repo.SearchAsync(query));
        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        private bool VerifyPassword(string password, string storedHash)
        {
            return HashPassword(password) == storedHash;
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _repo.GetAllAsync());

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var doctor = await _repo.GetByIdAsync(id);
            await _repo.DeleteAsync(doctor);
            return Ok();
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, DoctorUpdateDTO dto)
        {
            var doctor = await _repo.GetByIdAsync(id);
            doctor.Name = dto.Name;
            doctor.Email = dto.Email;
            doctor.Surname = dto.Surname;
            doctor.Age = dto.Age;
            doctor.Salary = dto.Salary;
            doctor.Education = dto.Education;
            doctor.FIN = dto.FIN;
            doctor.Series = dto.Series;
            doctor.Address = dto.Address;
            doctor.DepartmentId = dto.DepartmentId;
            doctor.Gender = (Gender)dto.Gender;
            doctor.Birthday = dto.Birthday;
            await _repo.UpdateAsync(doctor);
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetDoctorsByGender(int gender) => Ok(await _repo.GetDoctorsByGenderAsync(gender));
        [HttpGet]
        public async Task<IActionResult> GetDoctorsByDepartment(string department) => Ok(await _repo.GetDoctorsByDepartmentAsync(department));
    }
}


