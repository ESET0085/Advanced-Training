using College_App.Data;
using College_App.Data.Repository;
using College_App.Model.Mylogger;
using Microsoft.EntityFrameworkCore;

namespace CollegeApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDbContext<CollegeDBContext> (options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionDB"));

            });
            //builder.Services.AddScoped<IStudentRepository, StudentRepository>();
            builder.Services.AddControllers().AddNewtonsoftJson();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IMylogger, LogtoDB>();
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));


            var app = builder.Build();

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



        }
    }
}
