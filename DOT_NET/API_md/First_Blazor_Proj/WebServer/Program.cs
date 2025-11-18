
using Microsoft.EntityFrameworkCore;

namespace WebServer
{
    public class Program
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                var builder = WebApplication.CreateBuilder(args);

                // ?? Add DbContext
                builder.Services.AddDbContext<CollegeDbContext>(options =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

                // ?? Register Repositories
              

                // ?? Configure JWT Authentication
               
                    

                // ?? Configure Swagger with JWT support
                builder.Services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Title = "CollegeProject API",
                        Version = "v1",
                        Description = "JWT Authentication Enabled Web API"
                    });

                   

                

                // ?? Add Controllers
                builder.Services.AddControllers();
                builder.Services.AddEndpointsApiExplorer();
                builder.Services.AddControllers().AddNewtonsoftJson();

                //cors for diff project




                builder.Services.AddCors(options =>
                {
                    options.AddPolicy("AllowUI", policy =>
                    {
                        policy.WithOrigins("https://localhost:7150") // your UI project's URL
                         .AllowAnyHeader()
                         .AllowAnyMethod();
                    });
                });


                var app = builder.Build();

                // ?? Middleware
                if (app.Environment.IsDevelopment())
                {
                    app.UseSwagger();
                    app.UseSwaggerUI();
                }

                app.UseHttpsRedirection();

                app.UseCors("AllowUI");

                app.UseAuthentication();
                app.UseAuthorization();

                app.MapControllers();

                app.Run();
            }
        }
    }
