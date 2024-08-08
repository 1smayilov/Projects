
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.Abstract;
using Business.Concrete;
using Business.DependencyResolvers.Autofac;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args); 

            // Add services to the container.

            builder.Services.AddControllers();

            // Mən dotnetin corun IoC u yox öz yaratdığım IOC dən istifadə edəcəm 
            // Servis sağlayıcı fabrikası olarak kullan neyi?
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
            // Autofac - i harda istifadə edirsən 
            builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
            {
                builder.RegisterModule(new AutofacBusinessModule());
            });
            // Bu nəyə görə lazımdır - error qaytarır çünki İProductDalın nəyinə gedəcəyini bilmir
            // Mənə arxa planda bir referans oluştur, Əgər IProductService istəyərlərsə ProductManager new() i ver
            // IProductDal a da qarsiliq EfProductDal


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
