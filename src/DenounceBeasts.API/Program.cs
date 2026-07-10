using DenounceBeasts.API.Controllers;
using DenounceBeasts.Application.Controllers;
using DenounceBeasts.Application.Models;
using DenounceBeasts.Domain.Entities;
using DenounceBeasts.Infraestructure;
using DenounceBeasts.Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(cfg =>
{
    // Registrar el perfil manualmente (opcional):
    cfg.AddProfile<MappingProfile>();
}, typeof(Program).Assembly /* escanear automát. perfiles en el assembly */);

//var automapperKey = "asdjaskdjahskjdhkajshdkjahskjdhajshdjkashdkjhasjdhaskjd";
//var automapperLicence = builder.Configuration.GetSection("KeysConfigurations:AutomapperLicenceKey").Value;
//var automapperLicence2 = builder.Configuration.GetSection("AutomapperLicenceKey").Value;
///var settingValue = builder.Configuration.GetSection("Logging:LogLevel:Microsoft.AspNetCore").Value;
//
//builder.Services.AddAutoMapper(cfg => cfg.LicenseKey = automapperLicence, typeof(MappingProfile));

builder.Services.AddScoped<GenericRepository<ComplaintType>>();
builder.Services.AddScoped<GenericRepository<Municipality>>();
builder.Services.AddScoped<StatusRepository>();
builder.Services.AddScoped<SectorRepository>();

builder.Services.AddScoped<UnitOfWork>();

builder.Services.AddScoped<SectorService>();
builder.Services.AddScoped<ComplaintTypesService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
