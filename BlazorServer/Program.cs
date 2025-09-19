using BlazorServer.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(); 

            builder.Services.AddDbContext<CrudBlazorContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("ConexionSQL"));
            });

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("newPolicy", app =>
                {
                    app.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("newPolicy");
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
