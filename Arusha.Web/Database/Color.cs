using System.Collections.Generic;

namespace Arusha.Domain
{
    public class Color : Base
    {
        public string Key { get; set; }
        public string Name { get; set; }
        public string AlterName { get; set; }
        public virtual ICollection<Variant> Variants { get; set; }
    }
}
