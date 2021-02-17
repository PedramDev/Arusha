using System.Collections.Generic;

namespace Arusha.Domain
{
    public class Property : Base
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public ICollection<Variant> Variants { get; set; }
    }
}
