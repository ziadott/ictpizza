using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ictpizza.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly PizzaDbContext _context;

        public OrderController(PizzaDbContext context)
        {
            _context = context;
        }

        // GET: api/order
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            return await _context.Orders.Include(o => o.OrderItems).ThenInclude(oi => oi.Pizza).ToListAsync();
        }

        // GET: api/order/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var order = await _context.Orders.Include(o => o.OrderItems).ThenInclude(oi => oi.Pizza)
                                             .FirstOrDefaultAsync(o => o.OrderId == id);
            if (order == null)
                return NotFound();

            return order;
        }

        // POST: api/order
        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder(Order order)
        {
            // Calculate total price
            order.TotalPrice = order.OrderItems.Sum(oi => oi.Subtotal);

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOrder), new { id = order.OrderId }, order);
        }

        // PUT: api/order/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, Order order)
        {
            if (id != order.OrderId)
                return BadRequest();

            _context.Entry(order).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/order/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
                return NotFound();

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
