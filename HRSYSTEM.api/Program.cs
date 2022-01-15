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
using HRSYSTEM.application;
using HRSYSTEM.domain;

var builder = WebApplication.CreateBuilder(args);

// Database connection
builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("Default"), b => b.MigrationsAssembly("HRSYSTEM.api")));

builder.Services.AddControllers(options =>
{
    options.Filters.Add<GlobalExceptionFilter>();
}).AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
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

// Configure Options
builder.Services.Configure<PaginationOptions>(builder.Configuration.GetSection("Pagination"));

// Configure Repositories
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IJobCatalogRepository, JobCatalogRepository>();

// Configure Helpers
builder.Services.AddScoped<IJwtHelper, JwtHelper>();

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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
