using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    //Product veya DTOlar için validator böyle yazılıyor.
    //araştır.
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty(); //boş olamaz
            RuleFor(p => p.ProductName).MinimumLength(2); //min 2 karakter olmalı
            RuleFor(p => p.UnitPrice).NotEmpty(); //boş olamaz
            RuleFor(p => p.UnitPrice).GreaterThan(0); // 0 dan büyük olmalı.
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryId == 1); //Category 1 olunca fiyat 10 dan büyük olmalı
          //  RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("Ürünler A harfi ile başlamalıdır.");//kendimiz metod yazabiliriz.
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A"); //A ile başlıyorsa true döner ve çalışır. Yoksa patlar.
        }
    }
}
