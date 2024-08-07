﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Validation.FluentValidation
{
    public static class ValidationTool
    {
        // ValidationTool doğrulama əməliyyatını həyata keçirir.
        public static void Validate(IValidator validator, object entity) 
        {
            var context = new ValidationContext<object>(entity);
            var result = validator.Validate(context); // ProductValidator product - ı yoxlayır
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }

        }
    }
}
