using Microsoft.EntityFrameworkCore;
using System;
using TreyJewett_TechAssessment.Interfaces;
using TreyJewett_TechAssessment.Models;
using TreyJewett_TechAssessment.Services;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IHRService, HRService>();

// Add DB
builder.Services.AddDbContext<HRContext>(options =>
    options.UseSqlServer("Data Source=DESKTOP;Initial Catalog=AssessmentDB;Integrated Security=True;Trust Server Certificate=True;"));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
