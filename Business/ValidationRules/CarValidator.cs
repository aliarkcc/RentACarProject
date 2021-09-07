using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(x => x.ColorId).NotEmpty().WithMessage("ColorId Boş Geçilemez");
            RuleFor(x => x.DailyPrice).NotEmpty().WithMessage("Günlük Fiyat Boş Geçilemez");
        }
    }
}
