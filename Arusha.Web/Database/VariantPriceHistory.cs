using System;

namespace Arusha.Domain
{
    public abstract class VariantPriceHistory : Base
    {
        public VariantPriceHistory()
        {
            ModifiedAt = DateTimeOffset.UtcNow;
        }
        public virtual Variant Variant { get; set; }
        public int VariantId { get; set; }
        public decimal Price { get; set; }
        public DateTimeOffset ModifiedAt { get; set; }
    }
    public class VariantPriceSellHistory: VariantPriceHistory
    { }

    public class VariantPriceBuyHistory : VariantPriceHistory
    { }
}
