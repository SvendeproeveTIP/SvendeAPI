using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeMounAPI.Models
{
	// Model class for Vehicle table

	public class Vehicle
	{
		[Key]
		public long VehicleId { get; set; }
		public string VehicleName { get; set; }
		public decimal StartupPrice { get; set; }
		public bool IsRented { get; set; }
		public string Battery { get; set; }
		public double Lattitude { get; set; }
		public double Longtitude { get; set; }
		public bool UnderMaintenance { get; set; }

		// Foreign key to Vehicle Type table

		[ForeignKey("Type")]
		public long TypeId { get; set; }
		public virtual VehicleType Type { get; set; }

		public Vehicle(string vehicleName, decimal startupPrice, bool isRented, string battery, double lattitude, double longtitude, bool underMaintenance, long typeId)
		{
			VehicleName = vehicleName;
			StartupPrice = startupPrice;
			IsRented = isRented;
			Battery = battery;
			Lattitude = lattitude;
			Longtitude = longtitude;
			UnderMaintenance = underMaintenance;
			TypeId = typeId;
		}
	}
}

