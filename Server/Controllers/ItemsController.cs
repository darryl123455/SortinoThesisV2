using Microsoft.AspNetCore.Mvc;
using SortinoThesisV2.Shared.Models;
using System.Collections.Generic;
using System.Linq;

namespace SortinoThesisV2.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        // In-memory storage for items (replace with database in real apps)
        private static List<ItemModel> items = new List<ItemModel>();

        // GET: api/items
        [HttpGet]
        public IActionResult GetItems()
        {
            return Ok(items);
        }

        // GET: api/items/5
        [HttpGet("{id}")]
        public IActionResult GetItem(int id)
        {
            var item = items.FirstOrDefault(i => i.Id == id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        // POST: api/items
        [HttpPost]
        public IActionResult AddItem(ItemModel item)
        {
            item.Id = items.Any() ? items.Max(i => i.Id) + 1 : 1; // Auto-generate ID
            items.Add(item);
            return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item);
        }

        // PUT: api/items/5
        [HttpPut("{id}")]
        public IActionResult UpdateItem(int id, ItemModel updatedItem)
        {
            var item = items.FirstOrDefault(i => i.Id == id);
            if (item == null) return NotFound();

            item.Name = updatedItem.Name;
            item.Description = updatedItem.Description;
            return NoContent();
        }

        // DELETE: api/items/5
        [HttpDelete("{id}")]
        public IActionResult DeleteItem(int id)
        {
            var item = items.FirstOrDefault(i => i.Id == id);
            if (item == null) return NotFound();

            items.Remove(item);
            return NoContent();
        }
    }
}
