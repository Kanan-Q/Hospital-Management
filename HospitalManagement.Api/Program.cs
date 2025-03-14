﻿

//using HospitalManagement.BL.Middleware;
using HospitalManagement.BL;
using HospitalManagement.BL.Helper;
using HospitalManagement.BL.SignalR;
using HospitalManagement.Core.Repositories;
using HospitalManagement.DataAccess.Context;
using HospitalManagement.DataAccess.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json.Serialization;

namespace HospitalManagement.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer(builder.Configuration.GetConnectionString("AzureSql"));
            });

            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter 'Bearer {token}'"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                     {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
                      }
                      });
            });
            builder.Services.AddSignalR();
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            builder.Services.AddScoped<IPatientRepository, PatientRepository>();
            builder.Services.AddScoped<INurseRepository, NurseRepository>();
            builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
            builder.Services.AddScoped<IPatientAccountRepository, PatientAccountRepository>();
            builder.Services.AddScoped<IExpensesRepsitories, ExpensesRepositories>();
            builder.Services.AddScoped<ISanitaryRepository, SanitaryRepository>();
            builder.Services.AddScoped<ITherapistRepository, TherapistRepository>();
            builder.Services.AddScoped<IEquipmentRepository, EquipmentRepository>();
            builder.Services.AddScoped<IDiagnosticRepository, DiagnosticRepository>();
            builder.Services.AddScoped<IWorkDayRepository, WorkDayRepository>();
            builder.Services.AddScoped<ISanitaryWorkDayRepository, SanitaryWorkDayRepository>();
            builder.Services.AddScoped<IEquipmentWorkDayRepository, EquipmentWorkDayRepository>();
            builder.Services.AddScoped<ITherapistWorkDayRepository, TherapistWorkDayRepository>();
            builder.Services.AddScoped<IDiagnosticWorkDayRepository, DiagnosticWorkDayRepository>();
            builder.Services.AddScoped<INurseWorkDayRepository, NurseWorkDayRepository>();
            builder.Services.AddScoped<PatientJwtHelper>();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAnyOrigin", policy =>
                {
                    policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod(); 
                });
            });

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = builder.Configuration["Jwt:Issuer"],
                        ValidAudience = builder.Configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
                        ClockSkew = TimeSpan.Zero
                    };
                });


   
            builder.Services.AddControllers();
            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });

         
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSingleton<NotificationHub>();
            var app = builder.Build();
            app.UseForwardedHeaders();
            app.UseMiddleware<IpRestrictionMiddleware>();
            app.MapHub<NotificationHub>("/notificationHub");
  
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Doctor API v1"));
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                ScreenshotBlocker.BlockScreenshots();
            }

            app.Use(async (context, next) =>
            {
                context.Response.Headers["X-Content-Type-Options"] = "nosniff";
                context.Response.Headers["X-Frame-Options"] = "DENY";
                context.Response.Headers["Content-Security-Policy"] = "frame-ancestors 'none'";
                await next();
            });
            ProcessBlocker.StartMonitoring();
            app.UseCors("AllowAnyOrigin");
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
