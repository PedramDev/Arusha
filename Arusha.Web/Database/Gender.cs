using System.ComponentModel.DataAnnotations;

namespace Arusha.Domain
{
    public enum Gender
    {

        [Display(Name = "زن")]
        Female = 0,

        [Display(Name = "مرد")]
        Male = 1
    }
}
