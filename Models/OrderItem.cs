namespace PizzaApp.Models;
public class OrderItem
{
	public int OrderItemId { get; set; }

	public int OrderId { get; set; }
	public Order Order { get; set; } // Navigation property

	public int PizzaId { get; set; }
	public Pizza Pizza { get; set; } // Navigation property

	public int Quantity { get; set; }
	public decimal Subtotal { get; set; }
}

