using System.ComponentModel.DataAnnotations;

namespace Arusha.Domain
{
    public class Admin : Base
    {
        [Display(Name="نام")]
        public string Name { get; set; }

        [Display(Name="فامیل")]
        public string Family { get; set; }

        [Display(Name="نام کاربری")]
        public string Username { get; set; }

        [Display(Name="رمز عبور")]
        public string Password { get; set; }
    }
}
