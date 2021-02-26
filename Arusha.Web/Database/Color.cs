using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Arusha.Domain
{
    public class Color : Base
    {

        [Display(Name = "کلید")]
        public string Key { get; set; }

        [Display(Name = "نام")]
        public string Name { get; set; }

        [Display(Name = "نام ثانویه")]
        public string AlterName { get; set; }

        [Display(Name = "تنوع ها")]
        public virtual ICollection<Variant> Variants { get; set; }


        [Display(Name = "نام کامل")]
        public string FullName => Name + " | " + AlterName;
    }
}
