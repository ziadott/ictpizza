using Microsoft.EntityFrameworkCore;


namespace PizzaApp.Models;
public class PizzaDbContext : DbContext
{
	public PizzaDbContext(DbContextOptions<PizzaDbContext> options) : base(options) { }

	public DbSet<Pizza> Pizzas { get; set; }
	public DbSet<Order> Orders { get; set; }
	public DbSet<OrderItem> OrderItems { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<OrderItem>()
			.HasOne(oi => oi.Order)
			.WithMany(o => o.OrderItems)
			.HasForeignKey(oi => oi.OrderId);

		modelBuilder.Entity<OrderItem>()
			.HasOne(oi => oi.Pizza)
			.WithMany()
			.HasForeignKey(oi => oi.PizzaId);
	}
}

