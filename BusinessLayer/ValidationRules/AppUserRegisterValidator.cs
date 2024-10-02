using DTOLayer.DTOs.AppUserDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AppUserRegisterValidator : AbstractValidator<AppUserRegisterDTO>
    {
        public AppUserRegisterValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad boş ola bilməz");
            RuleFor(x => x.SurName).NotEmpty().WithMessage("Soyad boş ola bilməz");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail boş ola bilməz");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("İstifadəçi adı boş ola bilməz"); 
            RuleFor(x => x.UserName).NotEmpty().WithMessage("İstifadəçi adı boş ola bilməz");
            RuleFor(x => x.UserName).MinimumLength(5).WithMessage("Ən az 5 uzunluqda olmalıdır");
            RuleFor(x => x.UserName).MaximumLength(20).WithMessage("Ən çox 20 uzunluqda olmalıdır");
            RuleFor(x => x.Password).Equal(y => y.ConfirmPassword).WithMessage("Şifrələr uyğun deyil");
        }
    }
}
