using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
        // Mənə validator type - ı ver
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            // Əgər göndərilən validator type bir IValidator deyilsə onda exception qaytar
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new Exception("Bu bir doğrulama sınıfı değil");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            // bir şeyləri çalışma anında çalıştırır (Reflection)
            // Product validatorun bir instancesini oluştur
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            // Product validatorun base type nı tap və onun generic argümanlarından ilkini bul 
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            // Metodun parametrlərinə bax, validatorun tipi ilə eyni olan parametrləi tap
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
