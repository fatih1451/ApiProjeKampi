using ApiProjeKampi.WebApi.Entities;
using FluentValidation;

namespace ApiProjeKampi.WebApi.ValidationRules
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.ProductName).NotEmpty().WithMessage("Ürün adını boş geçmeyin!");
            RuleFor(x => x.ProductName).MinimumLength(3).WithMessage("En az 2 karakter girişi yapın!");
            RuleFor(x => x.ProductName).MaximumLength(50).WithMessage("En fazla 50 karakter veri girişi yapın!");

            RuleFor(x => x.Price).NotEmpty().WithMessage("Ürün Fiyatı boş geçilemez!")
                .GreaterThan(0).WithMessage("Ürün Fiyatı Negatif olamaz!")
                .LessThan(1000).WithMessage("Ürün fiyatı bu kadar yüksek olamaz, girdiğiniz değeri konrol edin!");

            RuleFor(x => x.Description).NotEmpty().WithMessage("Ürün açıklaması boş geçilemez!");
        }
    }
}
