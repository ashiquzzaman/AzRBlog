using System.ComponentModel.DataAnnotations;

namespace MvcWithMsUnit.Entities
{
    public class AccountType : Entity<int>
    {
        public int Id { get; set; }
        [StringLength(128)]
        public string Name { get; set; }

    }
}
