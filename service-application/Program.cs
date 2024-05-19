using Microsoft.EntityFrameworkCore;
using service_data.Models;
using System;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("service.application.ConnectionString");
builder.Services.AddDbContext<ServiceAppDbContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));



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
