//using HospitalManagement.DataAccess.Context;
//using Microsoft.AspNetCore.Http;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace HospitalManagement.BL.Middleware
//{
//    public class TokenBlacklistMiddleware
//    {
//        private readonly RequestDelegate _next;
//        private readonly IConfiguration _configuration;

//        public TokenBlacklistMiddleware(RequestDelegate next, IConfiguration configuration)
//        {
//            _next = next;
//            _configuration = configuration;
//        }

//        public async Task InvokeAsync(HttpContext httpContext)
//        {
//            var token = httpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

//            if (token != null)
//            {
//                // Token doğrulama və istifadəçi məlumatlarını əldə et
//                //var email = ValidateToken(token);

//                if (email != null)
//                {
//                    httpContext.Items["User"] = email; // Set user to httpContext
//                }
//            }

//            await _next(httpContext);
//        }

//        //private string ValidateToken(string token)
//        //{
//        //    var jwtHelper = new JwtHelper(_configuration);
//        //    return jwtHelper.ValidateJwtToken(token);
//        //}
//    }
//}
