using OnboardingCountriesDAL.Repositories;
using log4net;
using log4net.Config;
using OnBoardingCountriesBE.Extensions;
using OnBoardingCountriesBE.Logger;
using OnBoardingCountriesBE.MiddleWare;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

IConfiguration configuration = new ConfigurationBuilder()
    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddJsonFile("appsettings.json").Build();


builder.Services.AddMongoDBConfiguration(configuration);
builder.Services.AddApiService(builder.Configuration);
builder.Services.AddTransient<ICountriesRepository , CountriesRepository >();

builder.Services.AddTransient<ILog>(provider =>
{
    return Log4net._log;
});
builder.Services.AddCorsConfiguration();


var app = builder.Build();
builder.Services.HandleFillMongoDBData();

XmlConfigurator.Configure(new System.IO.FileInfo("Logger/log4net.config"));
app.UseCors("AllowOrigin");

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionHandlerMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
