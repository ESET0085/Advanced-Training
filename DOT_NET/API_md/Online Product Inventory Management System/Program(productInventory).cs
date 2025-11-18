using Microsoft.EntityFrameworkCore;
using Online_Product_Inventory_Management_System.Data;
using Online_Product_Inventory_Management_System.Models;
using Online_Product_Inventory_Management_System.Repositories;


namespace Online_Product_Inventory_Management_System
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            // 1️⃣ Register DbContext
            builder.Services.AddDbContext<ProductInventoryContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("ProductInventoryDB")));

            // 2️⃣ Register Generic Repository
            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            // 3️⃣ Add Controllers
            builder.Services.AddControllers();

            // 4️⃣ Add Swagger/OpenAPI
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

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
