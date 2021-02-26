using System;
using System.ComponentModel.DataAnnotations;

namespace Arusha.Domain
{
    public abstract class VariantPriceHistory : Base
    {
        public VariantPriceHistory()
        {
            ModifiedAt = DateTimeOffset.UtcNow;
        }
        [Display(Name = "تنوع")]
        public virtual Variant Variant { get; set; }
        [Display(Name = "تنوع")]
        public int VariantId { get; set; }
        [Display(Name = "قیمت")]
        public decimal Price { get; set; }
        [Display(Name = "آخرین ویرایش")]
        public DateTimeOffset ModifiedAt { get; set; }
    }
    public class VariantPriceSellHistory: VariantPriceHistory
    { }

    public class VariantPriceBuyHistory : VariantPriceHistory
    { }
}
