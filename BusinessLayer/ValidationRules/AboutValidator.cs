using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AboutValidator : AbstractValidator<About>
    {
        public AboutValidator()
        {
            RuleFor(x => x.Description).NotEmpty().WithMessage("Buranı boş qoya bilməzsiniz");
            RuleFor(x => x.Image1).NotEmpty().WithMessage("Zəhmət olmasa şəkil seçin");
            RuleFor(x => x.Description).MinimumLength(50).WithMessage("Zəhmət olmasa ən az 50 hərfdən ibarət cümlə qurun");
            RuleFor(x => x.Description).MaximumLength(1500).WithMessage("Açıqlama bu qədər uzun ola bilməz");

        }
    }
}
