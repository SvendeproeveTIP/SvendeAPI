using System;
namespace LeMounAPI.Models
{
	public class OrderModel
	{
        public DateTime OrderDate { get; set; }
        public bool OrderEnded { get; set; }
        public DateTime EndDate { get; set; }
        public double Price { get; set; }
        public long UserId { get; set; }
        public long VehicleId { get; set; }
    }
}

