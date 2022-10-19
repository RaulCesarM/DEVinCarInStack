
using System;
using System.Threading.Tasks;
using DEVinCar.Domain.Entities.Enuns;
using DEVinCar.Domain.Entities.Models;
using DEVinCar.Infra.Data.Context;
using Microsoft.Extensions.DependencyInjection;

namespace DEVinCar.Test
{
    public class UserApiTestMockData
    {
        public static async Task CreateUser(UserApiAppTest application, bool criar)
        {

            using (var scope = application.Services.CreateScope())
            {
                var provider = scope.ServiceProvider;

                using (var UserDbContext = provider.GetRequiredService<DevInCarDbContext>())
                {
                    await UserDbContext.Database.EnsureCreatedAsync();

                    if (criar)
                    {
                        await UserDbContext.Users.AddAsync(new User
                        {   
                            Name = "Amarildo soares",
                            BirthDate = new DateTime(2000, 12, 10),
                            Email = "Amarildo@Gmail.com",
                            Password = "1224tTio",
                            Permission = Permission.Gerente
                         });

                        await UserDbContext.Users.AddAsync(new User
                        {

                            Name = "Arlete soares",
                            BirthDate = new DateTime(2022, 12, 10),
                            Email = "ArleteGmail.com",
                            Password = "11111111",
                            Permission = Permission.Funcionario
                        });

                        //await UserDbContext.SaveChangesAsync();
                    }
                }

                
            }

            
        }
        
    }
}