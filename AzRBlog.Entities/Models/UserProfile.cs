using AzRBlog.Entities.Configs;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AzRBlog.Entities.Models
{
    public class UserProfile : AuditableEntity<long>
    {

        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Mobile { get; set; }

        [StringLength(500)]
        public string Address { get; set; }

        public string Biography { get; set; }

        [StringLength(50)]
        public string ZipCode { get; set; }

        [StringLength(50)]
        public string State { get; set; }

        [Display(Name = "Country")]
        public int? CountryId { get; set; }

        [ForeignKey("CountryId")]
        public Country Country { get; set; }

    }
}
