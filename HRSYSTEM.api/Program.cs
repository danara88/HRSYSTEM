using HRSYSTEM.persistance.Context;
using HRSYSTEM.api.JwtConfiguration;
using Microsoft.EntityFrameworkCore;
using HRSYSTEM.application.Mapping;
using HRSYSTEM.persistance.Repositories.Employee;
using FluentValidation.AspNetCore;
using MediatR;
using System.Reflection;
using Microsoft.AspNetCore.Authentication;
using HRSYSTEM.persistance;

var builder = WebApplication.CreateBuilder(args);

// Database connection
builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("Default"), b => b.MigrationsAssembly("HRSYSTEM.api")));

builder.Services.AddControllers(options =>
{
    options.Filters.Add<GlobalExceptionFilter>();
}).AddNewtonsoftJson(options =>
{
    // Ignore loop reference
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});

// Add cors policy
builder.Services.AddCors(options => options.AddPolicy("HrsystemPolicy", builder =>
{
    builder.WithMethods("GET", "POST", "PUT", "DELETE")
            .AllowAnyHeader()
            .Build();
}));

// Configure Auto Mappers
builder.Services.AddAutoMapper(typeof(ApplicationMapper));

// Configure Repositories
builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddTransient<IJobCatalogRepository, JobCatalogRepository>();

// Add jwt token authentication
builder.Services.AddTokenAuthentication(builder.Configuration);

// Add mediator
builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

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

app.UseCors("HrsystemPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
