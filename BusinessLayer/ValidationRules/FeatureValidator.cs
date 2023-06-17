using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class FeatureValidator : AbstractValidator<Feature>
    {
        public FeatureValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad kısmı boş geçilemez !");
            RuleFor(x => x.Name).MinimumLength(5).WithMessage("Ad alanı adı en az 5 karakter olmalıdır !");
            RuleFor(x => x.Name).MaximumLength(100).WithMessage("Ad alanı adı en fazla 50 karakter olmalıdır !");

            RuleFor(x => x.Header).NotEmpty().WithMessage("Özellik başlığı boş geçilemez !");
            RuleFor(x => x.Header).MinimumLength(5).WithMessage("Özellik başlığı en az 5 karakter olmalıdır !");
            RuleFor(x => x.Header).MaximumLength(100).WithMessage("Özellik başlığı en fazla 100 karakter olmalıdır !");

            RuleFor(x => x.Tiitle).NotEmpty().WithMessage("Özellik özet bilgi alanı boş geçilemez !");
            RuleFor(x => x.Tiitle).MinimumLength(5).WithMessage("Özellik özet bilgi alanı en az 5 karakter olmalıdır !");
            RuleFor(x => x.Tiitle).MaximumLength(100).WithMessage("Özellik özet bilgi alanı en fazla 500 karakter olmalıdır !");
        }
    }
}
