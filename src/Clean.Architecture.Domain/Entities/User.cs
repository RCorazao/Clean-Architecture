using Clean.Architecture.Domain.DataBase;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clean.Architecture.Domain.Entities
{
    [Table("users")]
    public class User : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
