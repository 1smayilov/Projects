using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    // Autofacin .Net-dən fərqi odur ki, Autofac bizə interceptor görevi de veriyor
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder) // 1.
        {
            builder.RegisterType<ProductManager>().As<IProductService>();
            builder.RegisterType<EfProductDal>().As<IProductDal>();

            builder.RegisterType<CategoryManager>().As<ICategoryService>();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();



            var assembly = System.Reflection.Assembly.GetExecutingAssembly();  // Buradakı, hazırda işləyən bütün sinifləri və interface ləri topla 

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces() 
                // Bu metod, əldə edilən hər bir sinifin implementasiya etdiyi interfeysi tapır və həmin sinifi o interfeys olaraq qeyd edir.
                // Yəni, sinifləri interfeyslər kimi qeyd edir.
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();

            // ProxyGenerationOptions obyektində Selector olaraq AspectInterceptorSelector istifadə olunur.
            // Bu, hansı interceptors-ların hansı metodlara əlavə ediləcəyini idarə edir.

        }
    }
}
