﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentACar.Models
{
	public class Maintenance
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string Type { get; set; }
		public string Description { get; set; }
		[Required]
		[Range(0.01, double.MaxValue, ErrorMessage = "The cost must be a positive number.")]
		public float Cost { get; set; } = 0f;
		public DateTime MaitenanceDate { get; set; } = DateTime.Now;
		[ForeignKey("Car")]
		public int? CarId { get; set; }
		public Car? Car { get; set; }
	}
}
