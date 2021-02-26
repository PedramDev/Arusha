using Arusha.Core;
using System.ComponentModel.DataAnnotations;

namespace Arusha.Domain
{
    public class Base
    {
        [Display(Name = "#")]
        public int Id { get; set; }
    }
}
