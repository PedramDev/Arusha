﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Arusha.Domain
{
    public class Variant : Base
    {
        public Variant()
        {
            CreatedAt = DateTimeOffset.UtcNow;
        }
        public DateTimeOffset CreatedAt { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public string Code { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public virtual ICollection<VariantPriceSellHistory> SellPriceHistory { get; set; }
        public virtual ICollection<VariantPriceBuyHistory> BuyPriceHistory { get; set; }
        public virtual ICollection<Property> Properties { get; set; }

        public int ColorId { get; set; }
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
    }
}
