using Microsoft.EntityFrameworkCore;
using service_data.Models;
using service_logic;
using service_logic.LogicAdmin;
using service_logic.LogicUsers;
using service_repository.Repositories.RepoAdmin;
using service_repository.Repositories.RepoUsers;
using System;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("service.application.ConnectionString");
builder.Services.AddDbContext<ServiceAppDbContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
builder.Services.AddScoped<IUserLogic, UserLogic>();
builder.Services.AddScoped<IAdminLogic, AdminLogic>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAdminRepository, AdminRepository>();


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
