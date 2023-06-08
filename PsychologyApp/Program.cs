using Microsoft.EntityFrameworkCore;
using PsychologyApp.WebApi.Models;
using PsychologyApp.WebApi.Services;
using PsychologyApp.WebApi.Services.Impl;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Database options

builder.Services.AddDbContext<PsychologyContext>(options => options
    .UseNpgsql(builder.Configuration.GetConnectionString("PsychologyContext"))
    .UseSnakeCaseNamingConvention());

builder.Services.AddDatabaseDeveloperPageExceptionFilter();
#endregion

#region Services

builder.Services.AddScoped<IPsychologistService, PsychologistService>();
builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.AddScoped<ISheduleService, SheduleService>();
builder.Services.AddScoped<ITherapyService, TherapyService>();

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
