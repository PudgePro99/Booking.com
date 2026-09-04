using Booking.com.Application.Interfaces;
using Booking.com.Application.Services;
using Booking.com.Infrastructure.Repositories;
using Booking.com.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

//регистрация DI
builder.Services.AddScoped<IRoomRepository, RoomRepository>();
builder.Services.AddScoped<IRoomService, RoomService>();

builder.Services.AddScoped<ISaveChanges, SaveChanges>();

builder.Services.AddScoped<IUserRepository , UserRepository>();
builder.Services.AddScoped<IUserService , UserService>();

builder.Services.AddScoped<IBookingRepository , BookingRepository>();
builder.Services.AddScoped<IBookingService, BookingService>();

builder.Services.AddDbContext<AppDbContext>
    (options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

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

app.MapControllers();

app.Run();