using Microsoft.EntityFrameworkCore;
using dotnetapp.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using dotnetapp.Models;
using dotnetapp.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString")));

builder.Services.AddScoped<ApplicationDbContext>(); // Add this line to register ApplicationDbContext as a scoped service
    builder.Services.AddScoped<IOrderService, OrderService>(); // Assuming you have an IOrderService
    builder.Services.AddScoped<OrderRepository>();
    builder.Services.AddScoped<IBookService, BookService>(); // Assuming you have an IOrderService
    builder.Services.AddScoped<BookRepository>();


builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin",
        builder => builder.WithOrigins()
            .AllowAnyHeader()
            .AllowAnyMethod());
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("AllowOrigin");

app.MapControllers();

app.Run();
