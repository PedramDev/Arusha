using Arusha.Core;
using System.Linq;
using System.Text;

namespace Arusha.Domain
{
    public class OrderItems : Base
    {
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }

        public virtual Variant Variant { get; set; }
        public int? VariantId { get; set; }
        public string VariantName { get; set; }


        public virtual Product Product { get; set; }
        public int? ProductId { get; set; }
        public string ProductName { get; set; }

        public virtual Category Category { get; set; }
        public string CategoryName { get; set; }

        public decimal SinglePayedPrice { get; set; }
        public decimal SingleSellPrice { get; set; }
        public decimal SingleBuyPrice { get; set; }

        public int Quantity { get; set; }

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
