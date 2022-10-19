using DEVinCar.Infra.Data.Context;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;

namespace DEVinCar.Test
{
    public class UserApiAppTest : WebApplicationFactory<Program>
    {
        protected override IHost CreateHost(IHostBuilder builder)
        {
            var root = new InMemoryDatabaseRoot();
            builder.ConfigureServices(services =>{
                services.RemoveAll(typeof(DbContextOptions<DevInCarDbContext>));
                services.AddDbContext<DevInCarDbContext>(options =>
                options.UseInMemoryDatabase("INCAR", root));
            });
            return base.CreateHost(builder);
        }
    }
}