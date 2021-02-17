using System;
using System.Collections.Generic;
using System.Linq;

namespace Arusha.Domain
{
    public class Order : Base
    {
        public int? UserId { get; set; }
        public virtual User User { get; set; }

        public string BillingMobile { get; set; }
        public string BillingName { get; set; }
        public string BillingFamily { get; set; }
        public string BillingEmail { get; set; }
        public Gender BillingGender { get; set; }

        public virtual ICollection<OrderItems> Items { get; set; }

        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }

        public decimal ShippingCost { get; set; }

        public int ShippingMethodId { get; set; }
        public virtual ShippingMethod ShippingMethod { get; set; }

        public int GetTotalItems()
        {
            if (Items != null)
            {
                return Items.Sum(x => x.Quantity);
            }
            return 0;
        }
        public decimal GetTotalSellPrice()
        {
            if (Items != null)
            {
                return Items.Sum(x => x.SingleSellPrice);
            }
            return 0;
        }
        public decimal GetTotalBuyPrice()
        {
            if (Items != null)
            {
                return Items.Sum(x => x.SingleBuyPrice);
            }
            return 0;
        }
        public decimal GetTotalProfit()
        {
            if (Items != null)
            {
                return Items.Sum(x => x.GetTotalProfit());
            }
            return 0;
        }
    }
}
