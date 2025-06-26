using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidation
{
    public class MemberValidator : AbstractValidator<Member>
    {
        public MemberValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().WithMessage("Üye Adı boş geçilemez");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Üye Soyadı boş geçilemez");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Üye adı en az üç karakter olmalıdır");
            RuleFor(x => x.Surname).MinimumLength(2).WithMessage("Üye soyadı en az iki karakter olmalıdır");


        }
    }
}
