using HospitalManagement.BL.Enum;
using HospitalManagement.Core.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Core.Data
{
    //public static class SeedData
    //{
    //    public static async Task Initialize(IServiceProvider serviceProvider, UserManager<Doctor> userManager, RoleManager<IdentityRole> roleManager)
    //    {
    //        foreach (Roles role in Enum.GetValues(typeof(Roles)))
    //        {
    //            var roleExist = await roleManager.RoleExistsAsync(role.ToString());
    //            if (!roleExist)
    //            {
    //                var newRole = new IdentityRole(role.ToString());
    //                await roleManager.CreateAsync(newRole);
    //            }
    //        }

    //        var adminUser = await userManager.FindByNameAsync("admin");
    //        if (adminUser == null)
    //        {
    //            var user = new Doctor
    //            {
    //                FullName = "Admin",
    //                UserName = "admin",
    //                Email = "admin@mail.com",
    //            };

    //            var result = await userManager.CreateAsync(user, "Admin@1234");

    //            if (result.Succeeded)
    //            {
    //                await userManager.AddToRoleAsync(user, Roles.Admin.ToString());
    //            }
    //        }
    //    }
    //}
}
