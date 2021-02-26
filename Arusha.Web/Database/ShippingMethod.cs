using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Arusha.Domain
{
    public class ShippingMethod : Base
    {
        [Display(Name = "نام")]
        public string Name { get; set; }
        [Display(Name = "سفارشات")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
