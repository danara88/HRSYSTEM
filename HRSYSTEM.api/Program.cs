using HRSYSTEM.persistance.Context;
using HRSYSTEM.api.JwtConfiguration;
using Microsoft.EntityFrameworkCore;
using HRSYSTEM.application.Mapping;
using HRSYSTEM.persistance.Repositories.Employee;
using FluentValidation.AspNetCore;
using HRSYSTEM.persistance.Filters;

var builder = WebApplication.CreateBuilder(args);

// Database connection
builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("Default"), b => b.MigrationsAssembly("HRSYSTEM.api")));

builder.Services.AddControllers().AddNewtonsoftJson(options =>
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

// Add jwt token authentication
builder.Services.AddTokenAuthentication(builder.Configuration);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add fluent validator and filters
builder.Services.AddMvc(options =>
{
    options.Filters.Add<ValidatorFilter>();
})
.AddFluentValidation(options =>
{
    options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
});

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
