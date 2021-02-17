using System.Collections.Generic;
using System.Linq;

namespace Arusha.Domain
{
    public class Product : Base
    {
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public ICollection<Variant> Variants { get; set; }
        public IEnumerable<Color> GetColors()
        {
            if(Variants != null)
            {
               return Variants.ToList().Select(x => x.Color);
            }
            return null;
        }
    }
}
