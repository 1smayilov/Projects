using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    // Dependency Resolvers - Bağımlılık çözümleme 
    // Product managerdə _cardal = cardal söhbəti
    // İProductDalın qarşılığı nədir 
    // İCardalın qarşılığı nədir
    // Bunları Autofac ilə düzəldəciyik
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        { 
            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance(); // Tək bir instance oluşsun hamıya onu versin 
            // Biri səndən Iproductservice istəsə ona productmanager ı register et  
            builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();

            // Bütün siniflərimiz üçün birinci Selectoru işlədir, get bax deyir gör bunun aspecti var?

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
