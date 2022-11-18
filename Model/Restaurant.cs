using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Restaurant
    {
        public Restaurant()
        {

        }
        public Restaurant(string name, string line1, string? line2, string suburb, string postcode)
        {
            Name = name;
            Line1 = line1;
            Line2 = line2;
            Suburb = suburb;
            Postcode = postcode;
        }
        public Restaurant(string name, string line1, string suburb, string postcode)
        {
            Name = name;
            Line1 = line1;
            Suburb = suburb;
            Postcode = postcode;
        }
        public Guid Id { get; set; }
        [StringLength(16, MinimumLength = 2)]
        public string? Name { get; set; }
        [StringLength(64, MinimumLength = 5)]
        public string? Line1 { get; set; }
        [StringLength(64, MinimumLength = 5)]
        public string? Line2 { get; set; }
        [StringLength(32, MinimumLength = 2)]
        public string? Suburb { get; set; }
        public string? Postcode { get; set; }
        public virtual Owner? Owner { get; set; }
    }
}