using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentCar.Models.Entity
{
    [Table("rents")]
    public class RentEntity: BaseEntity
    {
        [Column("car_id")] public int CarId { get; set; }

        public CarEntity? Car { get; set; }

        [Column("user_id")] public int UserId { get; set; }
        
        public UserEntity? User { get; set; }

        [Column("start_date")] public DateTime StartDate { get; set; }

        [Column("end_date")] public DateTime EndDate { get; set; }

        [Column("actual_end_date")] public DateTime? ActualEndDate { get; set; }

        [Column("total_amount")] public decimal TotalAmount { get; set; }

        [Column("status")] public string Status { get; set; } = string.Empty;
    }
}