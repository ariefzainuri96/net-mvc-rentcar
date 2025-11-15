using System.ComponentModel.DataAnnotations.Schema;

namespace RentCar.Models.Entity
{
    [Table("users")]
    public class UserEntity: BaseEntity
    {
        [Column("name")]
        public string Name { get; set; } = string.Empty;

        [Column("email")]
        public string Email { get; set; } = string.Empty;

        [Column("password")]
        public string Password { get; set; } = string.Empty;

        [Column("role")]
        public string Role { get; set; } = string.Empty;
    }
}
