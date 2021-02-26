using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Arusha.Domain
{
    public class Category : Base
    {
        [Display(Name="نام")]
        public string Name { get; set; }

        [Display(Name="پدر")]
        public int? ParentId { get; set; }


        [Display(Name = "پدر")]
        public virtual Category Parent { get; set; }

        [Display(Name = "فرزندان")]
        public virtual ICollection<Category> Childs { get; set; } = new List<Category>();

        [Display(Name = "محصولات")]
        public virtual ICollection<Product> Products { get; set; }


        [Display(Name = "نام کامل")]
        public string FullName => Name;
    }
}
