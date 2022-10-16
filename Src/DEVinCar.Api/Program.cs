using DEVinCar.Di.IOC;
using DEVinCar.Infra.Data.Context;
using Microsoft.AspNetCore.Mvc.Formatters;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

RepositoryIOC.RegisterServices(builder.Services);
ValidatorsIOC.RegisterServices(builder.Services);
AuthenticationIOC.RegisterServices(builder.Services);
builder.Services.AddMemoryCache();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMvc(config =>{
                config.ReturnHttpNotAcceptable = false;
                config.OutputFormatters.Add(new XmlSerializerOutputFormatter());
                config.InputFormatters.Add(new XmlSerializerInputFormatter(config));
});
var app = builder.Build();
if (app.Environment.IsDevelopment()){
    app.UseSwagger();
    app.UseSwaggerUI();
}
    app.UseCors(opcoes => opcoes.AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader());
    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
    public partial class Program{}




