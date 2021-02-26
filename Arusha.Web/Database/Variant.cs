using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Arusha.Domain
{
    public class Variant : Base
    {
        public Variant()
        {
            CreatedAt = DateTimeOffset.UtcNow;
        }
        [Display(Name = "تاریخ ثبت")]
        public DateTimeOffset CreatedAt { get; set; }
        [Display(Name = "نام")]
        public string Name { get; set; }
        [Display(Name = "تعداد در اتبار")]
        public int Stock { get; set; }
        [Display(Name = "کد محصول")]
        public string Code { get; set; }

        [Display(Name = "محصول")]
        public int ProductId { get; set; }
        [Display(Name = "محصول")]
        public virtual Product Product { get; set; }

        [Display(Name = "قیمت فروش")]
        public virtual ICollection<VariantPriceSellHistory> SellPriceHistory { get; set; }
        [Display(Name = "قیمت خرید")]
        public virtual ICollection<VariantPriceBuyHistory> BuyPriceHistory { get; set; }
        [Display(Name = "ویژگی ها")]
        public virtual ICollection<Property> Properties { get; set; }

        [Display(Name = "رنگ")]
        public int ColorId { get; set; }
        [Display(Name = "رنگ")]
        public virtual Color Color { get; set; }


        public decimal GetBuyPrice()
        {
            if (BuyPriceHistory != null)
            {
                return BuyPriceHistory.Last().Price;
            }
            return 0;
        }

        public decimal GetSellPrice()
        {
            if (SellPriceHistory != null)
            {
                return SellPriceHistory.Last().Price;
            }
            return 0;
        }

        [Display(Name = "نام کامل")]
        public string FullName => Name + " " +Product.FullName;
    }
}
