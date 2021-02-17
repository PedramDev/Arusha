using System.Collections.Generic;

namespace Arusha.Domain
{
    public class Category : Base
    {
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public virtual Category Parent { get; set; }
        public virtual ICollection<Category> Childs { get; set; } = new List<Category>();
        public virtual ICollection<Product> Products { get; set; }
    }
}
