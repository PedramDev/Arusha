using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Arusha.Domain
{
    public class Product : Base
    {

        [Display(Name = "نام")]
        public string Name { get; set; }

        [Display(Name = "دسته")]
        public int CategoryId { get; set; }

        [Display(Name = "دسته")]
        public virtual Category Category { get; set; }

        [Display(Name = "تنوع ها")]
        public ICollection<Variant> Variants { get; set; }

        public IEnumerable<Color> GetColors()
        {
            if(Variants != null)
            {
               return Variants.ToList().Select(x => x.Color);
            }
            return null;
        }

        [Display(Name = "نام کامل")]
        public string FullName => Name + " " + Category.Name;
    }
}
