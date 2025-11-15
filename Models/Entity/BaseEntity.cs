using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentCar.Models.Entity
{
    public class BaseEntity
    {
        [Column("id")] public int Id { get; set; }

        [Column("created_at")] public DateTimeOffset CreatedAt { get; set; }

        [Column("updated_at")] public DateTimeOffset? UpdatedAt { get; set; }

        [Column("deleted_at")] public DateTimeOffset? DeletedAt { get; set; }
    }
}