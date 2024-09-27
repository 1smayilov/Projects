using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidateRules.FluentValidation
{
    public class BrandValidator : AbstractValidator<Brand>
    {
        public BrandValidator()     
        {
            RuleFor(b=>b.BrandName).NotEmpty();
            RuleFor(b => b.BrandName).MinimumLength(2);
            RuleFor(b => b.BrandName).Must(EndWithS).WithMessage("Avtomobil adının son hərfi s ilə bitməlidir");
        }

        private bool EndWithS(string arg)
        {
            return arg.EndsWith("s");
        }
    }   
}
