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
using service_repository.Repositories.RepoMessage;
using service_logic.LogicMessage;
using service_repository.Repositories.RepoTicket;
using service_logic.LogicTicket;
using Microsoft.AspNetCore.Identity;
using service_data.Models.EntityModels;
using service_application.Services;
using service_data.Models.Mappers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using service_repository.Repositories.RepoInterval;
using service_logic.LogicInterval;

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

builder.Services.AddSingleton<IPasswordService, PasswordService>();
builder.Services.AddSingleton<IAuthService, AuthService>();


builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserLogic, UserLogic>();

builder.Services.AddScoped<IAdminRepository, AdminRepository>();
builder.Services.AddScoped<IAdminLogic, AdminLogic>();

builder.Services.AddScoped<IHandymanRepository, HandymanRespository>();
builder.Services.AddScoped<IHandymanLogic, HandymanLogic>();

builder.Services.AddScoped<ICostumerRepository, CostumerRepository>();
builder.Services.AddScoped<ICostumerLogic, CostumerLogic>();

builder.Services.AddScoped<IMessageRepository, MessageRepository>();
builder.Services.AddScoped<IMessageLogic, MessageLogic>();

builder.Services.AddScoped<ITicketRepository, TicketRepository>();
builder.Services.AddScoped<ITicketLogic, TicketLogic>();

builder.Services.AddScoped<IIntervalRepository, IntervalRepository>();
builder.Services.AddScoped<IIntervalLogic, IntervalLogic>();

builder.Services.AddSingleton<IAdminMapper, AdminMapper>();
builder.Services.AddSingleton<ICostumerMapper, CostumerMapper>();
builder.Services.AddSingleton<IHandymanMapper, HandymanMapper>();
builder.Services.AddSingleton<IMessageMapper, MessageMapper>();
builder.Services.AddSingleton<ITicketMapper, TicketMapper>();
builder.Services.AddSingleton<IUserMapper, UserMapper>();


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add JWT Authentication Middleware - This code will intercept HTTP request and validate the JWT.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
    opt => {
        opt.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
            .GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    }
  );

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
