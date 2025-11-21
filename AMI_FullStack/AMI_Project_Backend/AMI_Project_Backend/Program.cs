using AMI_Project_Backend.Data;
using AMI_Project_Backend.Helpers;
using AMI_Project_Backend.Interfaces;
using AMI_Project_Backend.Repositories;
using AMI_Project_Backend.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Security.Claims;
using System.Text;
using System.Text.Json.Serialization;

namespace AMI_Project_Backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var configuration = builder.Configuration;

            // 1️⃣ Configure Database Connection
            var connectionString = configuration.GetConnectionString("connectedDB");
            builder.Services.AddDbContext<AMIDbContext>(options =>
                options.UseSqlServer(connectionString));

            // 2️⃣ Register Repositories and Services
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddScoped<IConsumerRepository, ConsumerRepository>();
            builder.Services.AddScoped<IMeterRepository, MeterRepository>();
            builder.Services.AddScoped<ITariffRepository, TariffRepository>();
            builder.Services.AddScoped<IBillingRepository, BillingRepository>();
            //builder.Services.AddScoped<IBillingService, BillingService>();
            builder.Services.AddScoped<IDataRepository, DataRepository>();
            builder.Services.AddScoped<IBillingService, BillingService>();
            builder.Services.AddScoped<IOrgUnitRepository, OrgUnitRepository>();
            builder.Services.AddScoped<ITariffSlabRepository, TariffSlabRepository>();
            builder.Services.AddScoped<IMeterReadingRepository, MeterReadingRepository>();

            // 3️⃣ AutoMapper
            builder.Services.AddAutoMapper(typeof(MappingProfile));

            // 4️⃣ Controllers + Fix JSON Reference Loops
            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                    options.JsonSerializerOptions.WriteIndented = true;
                });

            // 5️⃣ JWT Authentication
            var jwtSection = configuration.GetSection("Jwt");
            var key = Encoding.UTF8.GetBytes(jwtSection["Key"]);

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtSection["Issuer"],
                        ValidAudience = jwtSection["Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ClockSkew = TimeSpan.Zero,
                        RoleClaimType = ClaimTypes.Role
                    };
                });

            // 6️⃣ Swagger with JWT Support
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "AMI Project API",
                    Version = "v1",
                    Description = "AMI Backend API with JWT Authentication"
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter 'Bearer' [space] and then your valid token.\nExample: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..."
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });

            // ⭐️ MODIFICATION: Updated CORS policy to allow all origins
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins", // New policy name for clarity
                    policy =>
                    {
                        policy.WithOrigins("https://localhost:7183")
                              .AllowAnyHeader()
                              .AllowAnyMethod();
                        
                    });
            });
            var app = builder.Build();

            // 7️⃣ Middleware
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            // ⭐️ MODIFICATION: Applied the new "AllowAllOrigins" policy
            app.UseCors("AllowAllOrigins");

            // 🔒 Enable Authentication + Authorization
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}