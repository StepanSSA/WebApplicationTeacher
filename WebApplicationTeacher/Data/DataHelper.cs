using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApplicationTeacher.Domains;
using WebApplicationTeacher.Models;

namespace WebApplicationTeacher.Data
{
    public class DataHelper
    {
        private static IApplicationBuilder app;
        // для начального заполнения бд
        public async static void Seed(IApplicationBuilder _app)
        {
            app = _app;
            //  1) добавим базовые роли в систему
            var services = app.ApplicationServices;
            var userManager = services.GetRequiredService<UserManager<AppUser>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
            string password = "!Qwerty1";
            string[] rolesNames = {"boss"};
            string[] usersNames = {"Boss@mail.ru"};

            for (int i = 0; i < rolesNames.Length; i++)
            {
                string roleName = rolesNames[i];
                var role = await roleManager.FindByNameAsync(roleName);
                if (role == null)
                {
                    role = new IdentityRole()
                    {
                        Name = roleName
                    };
                    IdentityResult result = await roleManager.CreateAsync(role);
                    if (result.Succeeded)
                    {
                        var user = new AppUser()
                        {
                            UserName = usersNames[i]
                        };
                        result = await userManager.CreateAsync(user, password);
                        if (result.Succeeded)
                        {
                            await userManager.AddToRoleAsync(user, roleName);
                        }

                    }
                }
            }

            // 2) добавляем в базу
            var context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();

            if (context.Courses.Any()) return;

            context.Courses.AddRange(new SimpleCourseRepository().Courses);
            context.SaveChanges();
        }

        public static void SaveBuyerChanges(CourseBuyingModel model, ClaimsPrincipal user)
        {
            var services = app.ApplicationServices;
            var userManager = services.GetRequiredService<UserManager<AppUser>>();
            var context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            model.Account = userManager.GetUserId(user);
            model.Firstname = userManager.Users.FirstOrDefault(u => u.Id == model.Account).Firstname;
            model.Lastname = userManager.Users.FirstOrDefault(u => u.Id == model.Account).Lastname;
            model.Age = userManager.Users.FirstOrDefault(u => u.Id == model.Account).Age;
            context.CourseBuying.Add(model);
            context.SaveChanges();
        }
        public static void SaveChanges(Courses model)
        {
            var context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            context.Update(model);
            context.SaveChanges();
        }

        private static async void NewRole(int courseId, string accountId)
        {
            var services = app.ApplicationServices;
            var userManager = services.GetRequiredService<UserManager<AppUser>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
            var context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            
            string roleName = context.Courses.First(c => c.Id == courseId).Name;
            var role = await roleManager.FindByNameAsync(roleName);
            if (role == null)
            {
                role = new IdentityRole()
                {
                    Name = roleName
                };
                IdentityResult result = await roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    var newUser = await userManager.FindByIdAsync(accountId);
                    await userManager.AddToRoleAsync(newUser, roleName);
                    
                }
            }else
            {
                var newUser = await userManager.FindByIdAsync(accountId);
                await userManager.AddToRoleAsync(newUser, roleName);
            }

            context.SaveChanges();
        }
        public static void Confirm(CourseBuyingModel model)
        {
            int courseid = Convert.ToInt32(model.Course);
            string accountId = model.Account;
            NewRole(courseid, accountId);
        }

    }
}
