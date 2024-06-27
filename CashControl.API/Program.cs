using CashControl.API.Context;
using CashControl.API.Interfaces;
using CashControl.API.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IBankStatement, BankStatementService>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseCors(c =>
{
    c.AllowAnyHeader();
    c.AllowAnyOrigin();
    c.WithMethods("GET", "POST", "PUT", "DELETE", "HEAD", "OPTIONS");
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
