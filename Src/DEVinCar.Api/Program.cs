using DEVinCar.Api.Configs;
using DEVinCar.Di.IOC;
using DEVinCar.Domain.Services;
using DEVinCar.Infra.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

RepositoryIOC.RegisterServices(builder.Services);
ValidatorsIOC.RegisterServices(builder.Services);
AuthenticationIOC.RegisterServices(builder.Services);

builder.Services.AddMemoryCache();
builder.Services.AddScoped(typeof(CacheService<>));


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<DevInCarDbContext>();
builder.Services.AddApiVersioning(options =>
{
    options.ReportApiVersions = true;
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new ApiVersion(2, 0);
    options.ApiVersionReader = ApiVersionReader.Combine(
        new UrlSegmentApiVersionReader(),
        new QueryStringApiVersionReader("api-version"),
        new HeaderApiVersionReader("X-API-VERSION")
    );
});
builder.Services.AddVersionedApiExplorer(
    options =>
    {
        options.GroupNameFormat = "'v'VVV";
        options.SubstituteApiVersionInUrl = true;
    });
builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
builder.Services.AddSwaggerGen();
builder.Services.AddMvc(config =>
{
    config.ReturnHttpNotAcceptable = true;
    config.OutputFormatters.Add(new XmlSerializerOutputFormatter());
    config.InputFormatters.Add(new XmlSerializerInputFormatter(config));
});
builder.Services.AddSingleton(ConfigureAutoMapper.Configure());
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        foreach (var description in app.Services.GetRequiredService<IApiVersionDescriptionProvider>().ApiVersionDescriptions)
        {
            options.SwaggerEndpoint(
                $"/swagger/{description.GroupName}/swagger.json",
                description.GroupName.ToUpperInvariant()
            );
        }
    });
}
app.UseCors(opcoes => opcoes.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
public partial class Program { }




