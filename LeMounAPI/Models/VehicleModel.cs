using System;
namespace LeMounAPI.Models
{
	public class VehicleModel
	{
        public string VehicleName { get; set; }
        public decimal startupPrice { get; set; }
        public bool isRented { get; set; }
        public double Battery { get; set; }
        public decimal Lattitude { get; set; }
        public decimal Longtitude { get; set; }
        public bool UnderMaintenance { get; set; }
        public long TypeId { get; set; }
    }
}

