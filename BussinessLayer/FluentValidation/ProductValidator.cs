using EntityLayer.Concrete;
using FluentValidation;

namespace BussinessLayer.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ürün adı boş geçilemez");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Ürün adı en az 3 harf olmalıdır.");
            RuleFor(x => x.Stock).NotEmpty().WithMessage("Ürün stoğu boş geçilemez");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Ürün fiyatı boş geçilemez");
        }
    }
}
