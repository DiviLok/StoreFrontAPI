using Microsoft.EntityFrameworkCore;
using StoreFrontAPI.Model;

namespace StoreFrontAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors();
            
            builder.Services.AddControllers();
            

            // Add services to the container.
            builder.Services.AddDbContext<ClothContext>(options => options
            .UseSqlServer(builder.Configuration.GetConnectionString("default")));
            builder.Services.AddControllers();
            //builder.Services.AddTransient<DbContext, ClothContext>();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();
            app.UseCors(builder =>
            {
                builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            });
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseStaticFiles();
            app.UseRouting();

            app.MapControllers();

            app.Run();
        }

/*        public void ConfigureServices(IServiceCollection services)
        {
                        services.AddScoped<DbContext, ClothContext>();
        }*/
    }
}