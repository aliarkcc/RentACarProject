using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules
{
    public class RentalValidator:AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(r => r.CarId).NotEmpty().WithMessage("Araba Boş Geçilemez.");
            RuleFor(r => r.CustomerId).NotEmpty().WithMessage("Şirket Boş Geçilemez.");
        }
    }
}
