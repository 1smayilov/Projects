using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.IoC
{
    // Bizim autofac və ya WebApi da yaratdığımız injectionları istifadə etməyimizə yarayır Həm bu proyektdə həmçinin
    // (Windows Form və ya başqa platformalarda da istifadə edə bilək deyə)
    public static class ServiceTool
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        public static IServiceCollection Create(IServiceCollection services) // IServiceCollection services — xidmətlərin qeyd edildiyi kolleksiya.
        {
            ServiceProvider = services.BuildServiceProvider(); 
            // services.BuildServiceProvider() metodu çağrılır ki, bu da qeyd olunan xidmətlərdən bir
            // ServiceProvider yaradaraq onu ServiceProvider xüsusiyyətinə təyin edir.
            return services;
        }
    }
}

//Əgər bir tətbiqdə asılılıqların avtomatik olaraq idarə edilməsi və yenidən istifadəsi lazımdırsa, ServiceTool bu məqsədə xidmət edir. 
//    Məsələn, əgər bir Autofac konteyneri istifadə edirsinizsə, 
//    burada ServiceTool istifadə edərək konfiqurasiya edilmiş xidmətlərinizi daha sonra asanlıqla əldə edə bilərsiniz.
//Bu, xidmətlərin və asılılıqların effektiv şəkildə idarə edilməsini təmin edir, həmçinin kodun daha təmiz və təşkilatlı qalmasına kömək edir.