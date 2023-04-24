using System;
namespace LeMounAPI.Models
{
	public class VehicleModel
	{
        public string VehicleName { get; set; }
        public decimal StartupPrice { get; set; }
        public bool IsRented { get; set; }
        public string Battery { get; set; }
        public double Lattitude { get; set; }
        public double Longtitude { get; set; }
        public bool UnderMaintenance { get; set; }
        public long TypeId { get; set; }
    }
}

