using System;
using System.Dynamic;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TgAppCrates.Core.models;
using TgAppCrates.Core.Abstractions;
using TgAppCrates.DataAccess;
using TgAppCrates.DataAccess.repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(
        options =>
        {
            options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(AppDbContext)));
        });
builder.Services.AddScoped<ICardRepository, CardRepository>();
builder.Services.AddScoped<IUserFundsRepository, UserFundsRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

/*
1134784306
*/