using Business.Constants;
using Castle.DynamicProxy;
using Core.Extensions;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessAspects.Autofac
{
    // JWT
    public class SecuredOperation : MethodInterception
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor; // JWT üçün HTTP yə müraciət etmək üçün giriş

        public SecuredOperation(string roles)
        {
            _roles = roles.Split(','); // vergülü sildi və 2 elementli array
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
           // Autofac ilə yaratdığımız injectionları alacaq(IProductDal EfProductDal)

        }

        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role))
                {
                    return;
                }
            }
            throw new Exception("Səhv var");
        }
    }
}
