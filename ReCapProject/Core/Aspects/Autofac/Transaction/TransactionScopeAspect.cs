using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Core.Aspects.Autofac.Transaction
{
    public class TransactionScopeAspect : MethodInterception
    {
        public override void Intercept(IInvocation invocation)
        {
            using (TransactionScope transactionScope = new TransactionScope())
            {
                try
                {
                    invocation.Proceed(); 
                    transactionScope.Complete(); 
                }
                catch (System.Exception e)
                {
                    transactionScope.Dispose(); 
                    throw;
                }
            }
        }
    }
}

// Metod işə düşdü bu "Database in Ramında" tutulur hələki əgər əməliyyat uğurlu olarsa database ə əlavə olunur yoxsa geri qayıdır
