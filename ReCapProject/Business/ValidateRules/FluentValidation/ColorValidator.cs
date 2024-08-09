using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidateRules.FluentValidation
{
    public class ColorValidator : AbstractValidator<Color>
    {
        public ColorValidator()
        {
            RuleFor(c => c.ColorName).NotEmpty();
            RuleFor(c => c.ColorName).Must(StartWithString).WithMessage("Düzgün simvol ilə başlamır");
        }

        private bool StartWithString(string arg)
        {
            return arg.StartsWith("#");
        }
    }
}
