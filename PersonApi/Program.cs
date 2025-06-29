using AutoMapper;
using PersonApi.Mapping;
using Microsoft.EntityFrameworkCore;
using PersonApi.Data;
using PersonApi.Repositories;
using PersonApi.Services;
using PersonApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add DbContext with SQL Server
builder.Services.AddDbContext<PersonDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

var app = builder.Build();

app.UseCors(policy => policy
    .WithOrigins("http://localhost:3000") // URL вашего React-приложения
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials());

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<PersonDbContext>();
    dbContext.Database.EnsureCreated();

    if (!dbContext.Addresses.Any())
    {
        dbContext.Addresses.AddRange(
            new Address { City = "New York", AddressLine = "123 Main St" },
            new Address { City = "London", AddressLine = "456 Oxford St" },
            new Address { City = "Madrid", AddressLine = "123 Main St" },
            new Address { City = "Nizza", AddressLine = "456 Oxford St" },
            new Address { City = "New Orlean", AddressLine = "123 Main St" }
            
        );
        dbContext.SaveChanges();
    }
}

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