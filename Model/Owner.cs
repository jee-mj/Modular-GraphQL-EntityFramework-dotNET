using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Owner
    {
        public Owner()
        {

        }
        public Owner(string name)
        {
            Name = name;
        }

        public Guid Id { get; set; }
        [StringLength(32, MinimumLength = 3)]
        public string? Name { get; set; }
        public virtual ICollection<Restaurant>? Restaurants { get; set; }
    }
}
