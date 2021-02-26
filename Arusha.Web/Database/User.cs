using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Arusha.Domain
{
    public class User : Base
    {
        [Display(Name = "اسم")]
        public string Name { get; set; }
        [Display(Name = "فامیل")]
        public string Family { get; set; }
        [Display(Name = "موبایل")]
        public string Mobile { get; set; }
        [Display(Name = "ایمیل")]
        public string Email { get; set; }
        [Display(Name = "جنسیت")]
        public Gender Gender { get; set; }

        [Display(Name = "سفارشات")]
        public virtual ICollection<Order> Orders { get; set; }

        [NotMapped]
        [Display(Name = "نام کامل")]
        public string FullName =>
        Name + " " + Family + " | " + Mobile;
    }
}
