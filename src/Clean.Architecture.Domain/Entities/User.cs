using System.ComponentModel.DataAnnotations.Schema;
using Clean.Architecture.Domain.Entities.Base;

namespace Clean.Architecture.Domain.Entities
{
    [Table("users")]
    public class User : Entity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
