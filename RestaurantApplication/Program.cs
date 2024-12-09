using Microsoft.EntityFrameworkCore;
using EFC;
using RestaurantApplication.Profiles;
using Application.Services;
using Application.Repositories;
using Serilog;
using Application.Repositories.Operations;
using Contracts.Interfaces.IRepository;
using Contracts.Interfaces.IRepository.IOperations;
using Contracts.Interfaces.IServices;
using System.Net;
using Serilog.Events;
#pragma warning disable CS8604 // Possible null reference argument.

var builder = WebApplication.CreateBuilder(args);

var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();
builder.Configuration.AddJsonFile("appsettings.json");

var emailSettings = config.GetSection("Serilog:WriteTo:2:Args");
// Add services to the container.



Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("logs/logs.txt")
    .WriteTo.Email(
        from: emailSettings["FromEmail"],
        to: emailSettings["ToEmail"],
        host: emailSettings["MailServer"],
        port: Convert.ToInt32(emailSettings["Port"]),
        credentials: new NetworkCredential(emailSettings.GetSection("NetworkCredentials")["UserName"], emailSettings.GetSection("NetworkCredentials")["Password"]),
        subject: emailSettings["Subject"],
        restrictedToMinimumLevel: LogEventLevel.Error
    )
    .CreateLogger();

builder.Host.UseSerilog();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContextPool<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AppDBConnection"),
    b => b.MigrationsAssembly("RestaurantApplication")));

// AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Repositories
builder.Services.AddScoped(typeof(IRepository<,,,>), typeof(Repository<,,,>));
builder.Services.AddScoped(typeof(IGetRepository<,>), typeof(GetRepository<,>));
builder.Services.AddScoped(typeof(IDeleteRepository<>), typeof(DeleteRepository<>));
builder.Services.AddScoped(typeof(ICreateRepository<,,>), typeof(CreateRepository<,,>));
builder.Services.AddScoped(typeof(IUpdateRepository<,,>), typeof(UpdateRepository<,,>));

// UnitOfWork
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Services
builder.Services.AddScoped<IDrinkServices, DrinkServices>();
builder.Services.AddScoped<IFoodServices, FoodServices>();
builder.Services.AddScoped<IMenuServices, MenuServices>();
builder.Services.AddScoped<IQRCodeServices, QRCodeServices>();

// Email Sender
//builder.Services.AddScoped<IEmailSender, EmailSender>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();