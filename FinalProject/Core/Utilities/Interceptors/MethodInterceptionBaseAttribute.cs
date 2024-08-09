using Autofac.Features.Metadata;
using Castle.DynamicProxy;

namespace Core.Utilities.Interceptors
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    {
        public int Priority { get; set; } // Atributların sırası

        public virtual void Intercept(IInvocation invocation)
        {

        }
    }

    // Bu sinif bir neçə metodun işə düşmə vaxtını nəzarət etməyə imkan verəcək bir baza təmin edir. 
}

