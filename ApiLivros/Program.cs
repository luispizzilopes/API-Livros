using ApiLivros.Context;
using Microsoft.EntityFrameworkCore;

namespace ApiLivros
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            string SqlConnetion = builder.Configuration.GetConnectionString("StringConexao");
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseMySql(SqlConnetion, ServerVersion.AutoDetect(SqlConnetion)));

            builder.Services.AddCors(); 

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(c =>
            {
                c.AllowAnyMethod();
                c.AllowAnyOrigin();
                c.AllowAnyHeader();
            });

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}