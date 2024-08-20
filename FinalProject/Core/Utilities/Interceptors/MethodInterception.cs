using Castle.DynamicProxy;
using System;

namespace Core.Utilities.Interceptors
{
    public abstract class MethodInterception : MethodInterceptionBaseAttribute
    {
        // invocation : business methods
        protected virtual void OnBefore(IInvocation invocation) { }
        protected virtual void OnAfter(IInvocation invocation) { }
        protected virtual void OnException(IInvocation invocation, System.Exception e) { }
        protected virtual void OnSuccess(IInvocation invocation) { }
        public override void Intercept(IInvocation invocation) // Mənim işlətmək istədiyim metoddur bu (add) 
            // Burada söhbət belədir, bu metod nə vaxt işləsin metod işləməmiş(OnBefore), xəta alanda(OnException), uğurlu olanda(OnSuccess) və s
            // Mən gedib hansı metodu ovveride eləsəm o işləyəcək yəni, o birilər yox
        {
             
            var isSuccess = true;
            OnBefore(invocation); // 8.
            try
            {
                invocation.Proceed(); 
                // Əgər doğrulama uğurla keçirsə (ValidationTool), proxy metod çağırışını invocation.Proceed() vasitəsilə davam etdirir.
                // Burdakı catch ə düşmür yəqin məntiqi tutmusan
            }
            catch (Exception e)
            {
                isSuccess = false;
                OnException(invocation, e);
                throw;
            }
            finally
            {
                if (isSuccess)
                {
                    OnSuccess(invocation); // 10.
                }
            }
            
            OnAfter(invocation); // 11.
        }
    }
}


//Nədir bu MethodInterception?

//MethodInterception: Bu sinif MethodInterceptionBaseAttribute sinifindən miras alır və IInterceptor interfeysini istifadə edir.
//Bu, metodların çağırılmasını idarə etmək üçün daha spesifik davranışları təmin edir.

//Üzvlər və Əməliyyatlar:

//OnBefore: Bu metod, metod çağırılmadan əvvəl baş verəcək əməliyyatları təyin edir. Məsələn, metoddan əvvəl log yazmaq.

//OnAfter: Bu metod, metod çağırıldıqdan sonra baş verəcək əməliyyatları təyin edir. Məsələn, metod bitdikdən sonra resursları sərbəst buraxmaq.

//OnException: Bu metod, metod çağırışı zamanı bir səhv baş verərsə nə etməli olduğunu təyin edir. Məsələn, səhv baş verdiyi halda səhv mesajını loglamaq.

//OnSuccess: Bu metod, metod çağırışı uğurla bitdiyi halda nə etməli olduğunu təyin edir. Məsələn, metod uğurla bitdikdən sonra xüsusi bir əməliyyat yerinə yetirmək.

//Intercept: Bu metod, IInterceptor interfeysindən gəlir və metod çağırışını idarə etmək üçün istifadə olunur. Burada:

//OnBefore metodunu çağırır, metod çağırılmadan əvvəl əməliyyatları yerinə yetirir.

//invocation.Proceed(): Bu, orijinal metodun çağırılmasını təmin edir.

//OnException: Əgər metod çağırışı zamanı bir səhv baş verərsə, bu metod çağırılır.

//OnSuccess: Əgər metod çağırışı uğurla bitərsə, bu metod çağırılır.

//OnAfter: Metod çağırıldıqdan sonra hər hansı əlavə əməliyyatlar üçün istifadə olunur.

//Nə İş Görəcək?

//Bu sinif metod çağırışlarını fərqli mərhələlərdə (əvvəl, sonra, səhv zamanı, uğur zamanı) idarə etmək üçün bir struktur təqdim edir. Bu metodları fərdiləşdirərək (override edərək) metod çağırışlarından əvvəl və sonra baş verəcək əməliyyatları təyin edə bilərsiniz. Beləliklə, müxtəlif növ nəzarət və ya əlavə əməliyyatları metodlara əlavə etmək asan olur.

//Yəni, bu sinif metod çağırışları zamanı baş verəcək əməliyyatları mərkəzləşdirmək və daha yaxşı idarə etmək üçün bir şablon təmin edir.