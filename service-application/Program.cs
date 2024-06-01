using Microsoft.EntityFrameworkCore;
using service_data.Models;
using service_logic;
using service_logic.LogicAdmin;
using service_logic.LogicUsers;
using service_repository.Repositories.RepoAdmin;
using service_repository.Repositories.RepoUsers;
using System;
using System.Text.Json.Serialization;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using service_repository.Repositories.RepoHandyman;
using service_logic.LogicHandyman;
using service_repository.Repositories.RepoCostumer;
using service_logic.LogicCostumer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
    });


var connectionString = builder.Configuration.GetConnectionString("service.application.ConnectionString");
builder.Services.AddDbContext<ServiceAppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
           .UseLazyLoadingProxies());

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserLogic, UserLogic>();

builder.Services.AddScoped<IAdminRepository, AdminRepository>();
builder.Services.AddScoped<IAdminLogic, AdminLogic>();

builder.Services.AddScoped<IHandymanRepository, HandymanRespository>();
builder.Services.AddScoped<IHandymanLogic, HandymanLogic>();

builder.Services.AddScoped<ICostumerRepository, CostumerRepository>();
builder.Services.AddScoped<ICostumerLogic, CostumerLogic>();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
}));


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/", () =>
{

    return "Hello service-application";
});
app.UseCors("MyPolicy");

app.MapControllers();

app.Run();
