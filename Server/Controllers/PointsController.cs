using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SortinoThesisV2.Server.Data;
using SortinoThesisV2.Shared.Models;

namespace SortinoThesisV2.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PointsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PointsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Points
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PointsModel>>> GetPoints()
        {
            return await _context.Points.ToListAsync();
        }

        // GET: api/Points/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PointsModel>> GetPointsModel(int id)
        {
            var pointsModel = await _context.Points.FindAsync(id);

            if (pointsModel == null)
            {
                return NotFound();
            }

            return pointsModel;
        }

        // POST: api/Points
        [HttpPost]
        public async Task<ActionResult<PointsModel>> PostPointsModel(PointsModel pointsModel)
        {
            _context.Points.Add(pointsModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPointsModel), new { id = pointsModel.Id }, pointsModel);
        }

        // PUT: api/Points/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPointsModel(int id, PointsModel pointsModel)
        {
            if (id != pointsModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(pointsModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Points.Any(e => e.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Points/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePointsModel(int id)
        {
            var pointsModel = await _context.Points.FindAsync(id);
            if (pointsModel == null)
            {
                return NotFound();
            }

            _context.Points.Remove(pointsModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
