using Core.Entities.Concrete;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules
{
    public class UserValidator:AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName).MinimumLength(3).WithMessage("İsim En Az 2 Karakter Olmalıdır.");
            RuleFor(u => u.FirstName).MaximumLength(20).WithMessage("İsim En Fazla 20 Karakter Olmalıdır.");
            RuleFor(u => u.LastName).MinimumLength(2).WithMessage("Soyisim En Fazla 20 Karakter Olmalıdır.");
            RuleFor(u => u.LastName).MaximumLength(20).WithMessage("Soyisim En Fazla 20 Karakter Olmalıdır.");
        }
    }
}
