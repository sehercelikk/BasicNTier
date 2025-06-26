using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidation
{
    public class LocationValidator : AbstractValidator<Location>
    {
        public LocationValidator()
        {
            RuleFor(x => x.LocationName).NotEmpty().WithMessage("Lokasyon adı boş geçilemez");
            RuleFor(x => x.LocationName).MinimumLength(3).WithMessage("Lokasyon adı en az 3 karkater olmalıdır");

        }
    }
}
