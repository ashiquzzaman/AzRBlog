using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MvcWithMsUnit.Entities
{

    public class Country : Entity<int>
    {
        public Country()
        {
            Persons = new List<Person>();
        }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Country Name")]
        public string Name { get; set; }

        public List<Person> Persons { get; set; }
    }
}
