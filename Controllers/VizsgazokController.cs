using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using aspnet_backend_help.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using static aspnet_backend_help.Models.VizsgazoModel;
using aspnet_backend_help;

namespace ECDL_Megoldas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VizsgazokController : ControllerBase
    {
        private readonly AppContext _context;

        public VizsgazokController(DatabaseContext context)
        {
            _context = context;
        }

        // 📌 Összes vizsgázó lekérdezése
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vizsgazo>>> GetVizsgazok()
        {
            return await _context.Vizsgazok.Include(v => v.Vizsgatipus).ToListAsync();
        }

        // 📌 Egy vizsgázó lekérdezése ID alapján
        [HttpGet("{id}")]
        public async Task<ActionResult<Vizsgazo>> GetVizsgazo(int id)
        {
            var vizsgazo = await _context.Vizsgazok
                                  .Include(v => v.Vizsgatipus)
                                  .FirstOrDefaultAsync(v => v.Id == id);

            if (vizsgazo == null)
                return NotFound();

            return vizsgazo;
        }

        // 📌 Új vizsgázó létrehozása
        [HttpPost]
        public async Task<ActionResult<Vizsgazo>> PostVizsgazo([FromBody] Vizsgazo vizsgazo)
        {
            _context.Vizsgazok.Add(vizsgazo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetVizsgazo), new { id = vizsgazo.Id }, vizsgazo);
        }

        // 📌 Vizsgázó adatainak módosítása
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVizsgazo(int id, [FromBody] Vizsgazo vizsgazo)
        {
            if (id != vizsgazo.Id)
                return BadRequest();

            _context.Entry(vizsgazo).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // 📌 Vizsgázó törlése
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVizsgazo(int id)
        {
            var vizsgazo = await _context.Vizsgazok.FindAsync(id);

            if (vizsgazo == null)
                return NotFound();

            _context.Vizsgazok.Remove(vizsgazo);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
