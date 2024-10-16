using DTOLayer.DTOs.AnnouncementDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.AnnouncementValidationRules
{
    public class AnnouncementUpdateValidator : AbstractValidator<AnnouncementUpdateDto>
    {
        public AnnouncementUpdateValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlıq boş ola bilməz");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Elan boş ola bilməz");
            RuleFor(x => x.Title).MinimumLength(5).WithMessage("5 dən az ola bilməz");
            RuleFor(x => x.Content).MinimumLength(20).WithMessage("20 dən az ola bilməz");
            RuleFor(x => x.Title).MaximumLength(50).WithMessage("50 dən çox ola bilməz");
            RuleFor(x => x.Content).MinimumLength(500).WithMessage("500 dən çox  ola bilməz");
 
        }
    }
}
