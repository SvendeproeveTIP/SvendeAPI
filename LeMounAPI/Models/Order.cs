using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeMounAPI.Models
{
    // Model class for Order table

    public class Order
	{
		[Key]
		public int OrderId { get; set; }
		public DateTime OrderDate { get; set; }
		public bool OrderEnded { get; set; }
		public DateTime EndDate { get; set; }
		public double Price { get; set; }

		[ForeignKey("User")]
		public int UserId { get; set; }
		public virtual User User { get; set; }

		[ForeignKey("Vehicle")]
		public int VehicleId { get; set; }
		public virtual Vehicle Vehicle { get; set; }
	}

}

