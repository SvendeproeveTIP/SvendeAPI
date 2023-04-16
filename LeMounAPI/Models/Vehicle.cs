using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeMounAPI.Models
{
	// Model class for Vehicle table

	public class Vehicle
	{
		[Key]
		public int VehicleId { get; set; }
		public string VehicleName { get; set; }
		public decimal startupPrice { get; set; }
		public bool isRented { get; set; }
		public double Battery { get; set; }
		public decimal Lattitude { get; set; }
		public decimal Longtitude { get; set; }
		public bool UnderMaintenance { get; set; }

		// Foreign key to Vehicle Type table

		[ForeignKey("Type")]
		public int TypeId { get; set; }
		public virtual VehicleType Type { get; set; }
	}
}

