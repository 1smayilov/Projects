using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Interceptors
{

    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>
                (true).ToList();
            var methodAttributes = type.GetMethod(method.Name)
                .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            classAttributes.AddRange(methodAttributes);

            return classAttributes.OrderBy(x => x.Priority).ToArray();
        }
    }

//                                       Nədir bu AspectInterceptorSelector?

//AspectInterceptorSelector: Bu sinif IInterceptorSelector interfeysini implement edir.Bu, metodların üzərinə tətbiq ediləcək interceptorların seçilməsi və sıralanması üçün bir mexanizm təmin edir.

//Üzvlər və Əməliyyatlar:

//SelectInterceptors: Bu metod, bir metod üçün tətbiq ediləcək interceptorları seçir.Burada:

//type: Metodun olduğu sinifi təmsil edir.

//method: İncelənən metodun özüdür.

//interceptors: Mövcud interceptorların siyahısıdır.

//classAttributes: Sinif səviyyəsində tətbiq edilən interceptor atributlarını (metadata) əldə edir.

//methodAttributes: Metod səviyyəsində tətbiq edilən interceptor atributlarını (metadata) əldə edir.

//AddRange: Sinif və metod atributlarını birləşdirir.

//OrderBy(x => x.Priority): Interceptorları onların Priority(öncelik) dəyərlərinə görə sıralayır.

//ToArray(): Sıralanmış interceptorların siyahısını qaytarır.

                                                    //Nə İş Görəcək?

//Bu sinif metodlar üzərində tətbiq ediləcək interceptorları müəyyən edir və onların icra sırasını təyin edir.Başqa sözlə:

//Metodun və sinifin üzərinə tətbiq edilən interceptor atributlarını tapır.

//Bu interceptorları Priority dəyərlərinə görə sıralayır.

//Sıralanmış interceptorları metod çağırışı zamanı tətbiq edir.

//Bu, metodlar üçün müxtəlif interceptorların (məsələn, loglama, doğrulama və ya performans monitorinqi) düzgün şəkildə işləməsini təmin etmək üçün istifadə olunur.
}

