using Arusha.Core;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Arusha.Domain
{
    public enum OrderItemStatus
    {

        [Display(Name = "فروخته شده")]
        Sold =0,

        [Display(Name = "بازگشت")]
        Returned =1
    }
    public class OrderItems : Base
    {

        [Display(Name = "شماره سفارش")]
        public int OrderId { get; set; }

        [Display(Name = "سفارش")]
        public virtual Order Order { get; set; }


        [Display(Name = "تنوع")]
        public virtual Variant Variant { get; set; }

        [Display(Name = "تنوع")]
        public int? VariantId { get; set; }

        [Display(Name = "نام تنوع")]
        public string VariantName { get; set; }



        [Display(Name = "محصول")]
        public virtual Product Product { get; set; }

        [Display(Name = "محصول")]
        public int? ProductId { get; set; }

        [Display(Name = "نام محصول")]
        public string ProductName { get; set; }


        [Display(Name = "دسته")]
        public virtual Category Category { get; set; }

        [Display(Name = "دسته")]
        public int? CategoryId { get; set; }

        [Display(Name = "نام دسته")]
        public string CategoryName { get; set; }


        [Display(Name = "قیمت واحد پرداخت شده")]
        public decimal SinglePayedPrice { get; set; }

        [Display(Name = "قیمت واحد فروش")]
        public decimal SingleSellPrice { get; set; }

        [Display(Name = "قیمت واحد خرید")]
        public decimal SingleBuyPrice { get; set; }


        [Display(Name = "تعداد")]
        public int Quantity { get; set; }


        [Display(Name = "وضعیت")]
        public OrderItemStatus Status { get; set; }

        public decimal GetTotalProfit()
        {
            return GetSingleProfit() * Quantity;
        }

        public decimal GetSingleProfit()
        {
            return SingleSellPrice - SingleBuyPrice;
        }
        public string GetName()
        {
            StringBuilder result = new();
            if (CategoryName.HasValue())
            {
                result.Append(CategoryName);
            }
            if (ProductName.HasValue())
            {
                result.Append(ProductName);
            }
            if (VariantName.HasValue())
            {
                result.Append(VariantName);
            }
            return result.ToString();
        }
    }
}
