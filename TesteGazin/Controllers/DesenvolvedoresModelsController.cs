using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TesteGazinAPI.Data;
using TesteGazinAPI.Models;

namespace TesteGazinAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesenvolvedoresModelsController : ControllerBase
    {
        private readonly DataBaseContext _context;

        public DesenvolvedoresModelsController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: api/DesenvolvedoresModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DesenvolvedoresModel>>> GetDesenvolvedorItems()
        {
            return await _context.DesenvolvedorItems.ToListAsync();
        }

        // GET: api/DesenvolvedoresModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DesenvolvedoresModel>> GetDesenvolvedoresModel(int id)
        {
            var desenvolvedoresModel = await _context.DesenvolvedorItems.FindAsync(id);

            if (desenvolvedoresModel == null)
            {
                return NotFound();
            }

            return desenvolvedoresModel;
        }

        // PUT: api/DesenvolvedoresModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<DesenvolvedoresModel>> PutDesenvolvedoresModel(int id, DesenvolvedoresModel desenvolvedoresModel)
        {
            if (id != desenvolvedoresModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(desenvolvedoresModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DesenvolvedoresModelExists(id))
                {
                    return BadRequest();
                }
                else
                {
                    throw;
                }
            }

            return desenvolvedoresModel;
        }

        // POST: api/DesenvolvedoresModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DesenvolvedoresModel>> PostDesenvolvedoresModel(DesenvolvedoresModel desenvolvedoresModel)
        {
            _context.DesenvolvedorItems.Add(desenvolvedoresModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDesenvolvedoresModel", new { id = desenvolvedoresModel.Id }, desenvolvedoresModel);
        }

        // DELETE: api/DesenvolvedoresModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDesenvolvedoresModel(int id)
        {
            var desenvolvedoresModel = await _context.DesenvolvedorItems.FindAsync(id);
            if (desenvolvedoresModel == null)
            {
                return BadRequest();
            }

            _context.DesenvolvedorItems.Remove(desenvolvedoresModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DesenvolvedoresModelExists(int id)
        {
            return _context.DesenvolvedorItems.Any(e => e.Id == id);
        }
    }
}
