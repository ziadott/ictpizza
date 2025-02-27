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
    public class PizzaController : ControllerBase
    {
        private readonly PizzaDbContext _context;

        public PizzaController(PizzaDbContext context)
        {
            _context = context;
        }

        // GET: api/pizza
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pizza>>> GetPizzas()
        {
            return await _context.Pizzas.ToListAsync();
        }

        // GET: api/pizza/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pizza>> GetPizza(int id)
        {
            var pizza = await _context.Pizzas.FindAsync(id);
            if (pizza == null)
                return NotFound();

            return pizza;
        }

        // POST: api/pizza
        [HttpPost]
        public async Task<ActionResult<Pizza>> CreatePizza(Pizza pizza)
        {
            _context.Pizzas.Add(pizza);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPizza), new { id = pizza.PizzaId }, pizza);
        }

        // PUT: api/pizza/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePizza(int id, Pizza pizza)
        {
            if (id != pizza.PizzaId)
                return BadRequest();

            _context.Entry(pizza).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/pizza/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePizza(int id)
        {
            var pizza = await _context.Pizzas.FindAsync(id);
            if (pizza == null)
                return NotFound();

            _context.Pizzas.Remove(pizza);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
