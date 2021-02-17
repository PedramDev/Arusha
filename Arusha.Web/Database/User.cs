using System.Collections.Generic;

namespace Arusha.Domain
{
    public class User : Base
    {
        public string Name { get; set; }
        public string Family { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
