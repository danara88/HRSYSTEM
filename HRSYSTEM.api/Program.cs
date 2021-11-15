using HRSYSTEM.persistance.Context;
using HRSYSTEM.api.JwtConfiguration;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Database connection
builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("Default"), b => b.MigrationsAssembly("HRSYSTEM.api")));

builder.Services.AddControllers();

// Add cors policy
builder.Services.AddCors(options => options.AddPolicy("HrsystemPolicy", builder =>
{
    builder.WithOrigins("http://localhost:4200")
            .WithMethods("GET", "POST", "PUT", "DELETE")
            .AllowAnyHeader()
            .Build();
}));

// Add jwt token authentication
builder.Services.AddTokenAuthentication(builder.Configuration);

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
