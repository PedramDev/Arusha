using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Arusha.Domain
{
    public class Property : Base
    {
        [Display(Name = "نام")]
        public string Name { get; set; }
        [Display(Name = "مقدار")]
        public string Value { get; set; }

        [Display(Name = "تنوع ها")]
        public ICollection<Variant> Variants { get; set; }
    }
}
