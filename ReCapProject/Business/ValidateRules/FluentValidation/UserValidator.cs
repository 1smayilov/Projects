using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidateRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u=>u.Firstname).NotEmpty();
            RuleFor(u=>u.Lastname).NotEmpty();
            RuleFor(u=>u.Password).NotEmpty();
        }
    }
}
