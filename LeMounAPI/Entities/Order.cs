using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeMounAPI.Models
{
    // Model class for Order table

    public class Order
	{
		[Key]
		public long OrderId { get; set; }
		public DateTime OrderDate { get; set; }
		public bool OrderEnded { get; set; }
		public DateTime EndDate { get; set; }
		public double Price { get; set; }

		[ForeignKey("User")]
		public long UserId { get; set; }
		public virtual User User { get; set; }

		[ForeignKey("Vehicle")]
		public long VehicleId { get; set; }
		public virtual Vehicle Vehicle { get; set; }

		public Order(DateTime orderDate, bool orderEnded, double price, long userId, long vehicleId)
		{
			OrderDate = orderDate;
			OrderEnded = orderEnded;
			Price = price;
			UserId = userId;
			VehicleId = vehicleId;
		}
	}

}

