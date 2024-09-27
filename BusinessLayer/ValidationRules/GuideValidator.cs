using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class GuideValidator : AbstractValidator<Guide>
    {
        public GuideValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().WithMessage("Zəhmət olmasa rəhbər adını daxil edin");
            RuleFor(x=>x.Description).NotEmpty().WithMessage("Zəhmət olmasa rəhbər açıqlamasını daxil edin");
            RuleFor(x=>x.Image).NotEmpty().WithMessage("Zəhmət olmasa rəhbər şəklini daxil edin");
            RuleFor(x=>x.Name).MaximumLength(30).WithMessage("Zəhmət olmasa 30 simvoldan çox daxil etməyin");
            RuleFor(x=>x.Name).MinimumLength(3).WithMessage("Zəhmət olmasa 3 simvoldan çox daxil edin");

        }
    }
}
