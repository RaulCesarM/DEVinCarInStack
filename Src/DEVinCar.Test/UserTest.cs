

using System.Collections.Generic;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using DEVinCar.Domain.Entities.Models;
using Xunit;

namespace DEVinCar.Test
{
    public class UserTest
    {        
        [Fact]
        public async Task Get_User_OK()
        {


            await using var application = new UserApiAppTest();

            await UserApiTestMockData.CreateUser(application, true);
            var url = "user";

            var client = application.CreateClient();

            var result = await client.GetAsync(url);
            var users = await client.GetFromJsonAsync<List<User>>("/user");

            Assert.Equal(HttpStatusCode.OK, result.StatusCode);          
            Assert.True(users.Count > 12);

        }

        [Fact]
        public async Task Get_User_ById_Failure_() {


            await using var application = new UserApiAppTest();

            await UserApiTestMockData.CreateUser(application, true);
            var url = "https://localhost:7019/user/dfsfsdfsdfsdfdsfsdfsdf";

            var client = application.CreateClient();

            var result = await client.GetAsync(url);
            var users = await client.GetFromJsonAsync<User>("/user");

            
            Assert.Equal(HttpStatusCode.BadRequest, result.StatusCode);


        }


        [Fact]
        public async Task Get_User_ById_Ok_() {


            await using var application = new UserApiAppTest();

            await UserApiTestMockData.CreateUser(application, true);
            var url = "/user";

            var client = application.CreateClient();

            var result = await client.GetAsync(url);
            var users = await client.GetFromJsonAsync<User>("/user/1");

            Assert.Equal(HttpStatusCode.OK, result.StatusCode);



        }


        [Fact]
        public async Task Padrao_de_teste_estudo()
        {
            // arrange


           //act 


           //asserts



        }


    }
}