using Castle.DynamicProxy;

namespace Core.Utilities.Interceptors
{
        // Classlara və ya metodlara ekliyebilirsin, birden çox ekliyebilirsin, inherit edilen bir noktada da bu atribut çalışsın
        [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
        public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
        {
            public int Priority { get; set; } // Hansı atribut birinci işləsin

            public virtual void Intercept(IInvocation invocation)
            {

            }

        }
    }
