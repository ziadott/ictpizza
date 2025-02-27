namespace PizzaApp.Models;
public class Order
{
	public int OrderId { get; set; }

	public decimal TotalPrice { get; set; }

	public string Status { get; set; } = "Pending"; // Default status

	public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

	// Navigation property for OrderItems
	public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}

