﻿using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidation
{
    public class CommentValidator : AbstractValidator<Comment>
    {
        public CommentValidator()
        {
            RuleFor(x=>x.CommentContent).NotEmpty().WithMessage("İçerik kısmı boş geçilemez");
            RuleFor(x => x.Status).NotEmpty().WithMessage("Durum kısmı boş geçilemez");
        }
    }
}
