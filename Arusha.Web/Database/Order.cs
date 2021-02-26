using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Arusha.Domain
{
    public class Order : Base
    {

        [Display(Name = "کاربر")]
        public int? UserId { get; set; }

        [Display(Name = "کاربر")]
        public virtual User User { get; set; }


        [Display(Name = "موبایل سفارش")]
        public string BillingMobile { get; set; }

        [Display(Name = "اسم سفارش")]
        public string BillingName { get; set; }

        [Display(Name = "فامیل سفارش")]
        public string BillingFamily { get; set; }

        [Display(Name = "ایمیل سفارش")]
        public string BillingEmail { get; set; }

        [Display(Name = "جنسیت سفارش")]
        public Gender BillingGender { get; set; }


        [Display(Name = "موارد")]
        public virtual ICollection<OrderItems> Items { get; set; }


        [Display(Name = "توضیحات")]
        public string Description { get; set; }

        [Display(Name = "تاریخ ثبت")]
        public DateTime CreatedAt { get; set; }


        [Display(Name = "هزینه ارسال")]
        public decimal ShippingCost { get; set; }


        [Display(Name = "شیوه ارسال")]
        public int ShippingMethodId { get; set; }

        [Display(Name = "شیوه ارسال")]
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
