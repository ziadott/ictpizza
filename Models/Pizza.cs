using System.ComponentModel.DataAnnotations;

namespace PizzaApp.Models;

public class Pizza
{
	public int PizzaId { get; set; }

	[Required, MaxLength(100)]
	public string Name { get; set; } = string.Empty;

	public string Description { get; set; } = string.Empty;

	[Required]
	public decimal Price { get; set; }

	public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}

