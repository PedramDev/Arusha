using System.Collections.Generic;

namespace Arusha.Domain
{
    public class ShippingMethod : Base
    {
        public string Name { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
