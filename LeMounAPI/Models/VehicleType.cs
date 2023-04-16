using System;
using System.ComponentModel.DataAnnotations;
namespace LeMounAPI.Models
{
    // Model class for Vehicle Type table

    public class VehicleType
	{
		[Key]
		public int TypeId { get; set; }
		public string Type { get; set; }

	}
}

