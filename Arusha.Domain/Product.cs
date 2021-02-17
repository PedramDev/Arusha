using System.Collections.Generic;

namespace Arusha.Domain
{
    public class Product : Base
    {
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public ICollection<Variant> Variants { get; set; }
    }
}
