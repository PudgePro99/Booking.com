using Booking.com.Application.Interfaces;
using Booking.com.Application.Services;
using Booking.com.Infrastructure.Data;
using Booking.com.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using System.Text;


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

builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddDbContext<AppDbContext>
    (options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
//swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Введите JWT токен"
    });

    options.AddSecurityRequirement(document =>
        new OpenApiSecurityRequirement
        {
            [
                new OpenApiSecuritySchemeReference("Bearer", document)
            ] = []
        });
});

//авторизация jwt
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var key = builder.Configuration["JWT:Key"];
        if (string.IsNullOrEmpty(key))
            throw new InvalidOperationException();
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),

            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["JWT:Issuer"],

            ValidateAudience = true,
            ValidAudience = builder.Configuration["JWT:Audience"],

            ValidateLifetime = true,

            ClockSkew = TimeSpan.Zero
        };
    });

var app = builder.Build();
//seeder
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider
        .GetRequiredService<AppDbContext>();

    await AdminSeeder.SeedAsync(dbContext);
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();