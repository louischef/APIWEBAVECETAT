using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIWEB.Models.EntityFramework;

namespace APIWEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeriesController : ControllerBase
    {
        private readonly TpdevContext _context;

        public SeriesController(TpdevContext context)
        {
            _context = context;
        }

        // GET: api/Series
        [HttpGet]
        [ProducesResponseType(200)]
        /// <summary>
        /// Get all series.
        /// </summary>
        /// <returns>Http response</returns>
        /// <response code="200">When the series is funded</response>
        public async Task<ActionResult<IEnumerable<Serie>>> GetSeries()
        {
            return await _context.Series.ToListAsync();
        }

        // GET: api/Series/5
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        /// <summary>
        /// Get a serie by his id.
        /// </summary>
        /// <returns>Http response</returns>
        /// <param name="id">The id of the serie</param>
        /// <response code="200">When the series is funded</response>
        /// <response code="404">When the series is not funded</response>
        public async Task<ActionResult<Serie>> GetSerie(int id)
        {
            var serie = await _context.Series.FindAsync(id);

            if (serie == null)
            {
                return NotFound();
            }

            return serie;
        }

        // PUT: api/Series/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        /// <summary>
        /// Get a serie by his id.
        /// </summary>
        /// <returns>Http response</returns>
        /// <param name="id">The id of the serie</param>
        /// <response code="201">When the series is modified</response>
        /// <response code="400">Modification refused</response>
        public async Task<IActionResult> PutSerie(int id, Serie serie)
        {
            if (id != serie.Serieid)
            {
                return BadRequest();
            }

            _context.Entry(serie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SerieExists(id))
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

        // POST: api/Series
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        /// <summary>
        /// Get a serie by his id.
        /// </summary>
        /// <returns>Http response</returns>
        /// <param name="id">The id of the serie</param>
        /// <response code="201">When the series is created</response>
        /// <response code="404">When creation is refused</response>
        public async Task<ActionResult<Serie>> PostSerie(Serie serie)
        {
            _context.Series.Add(serie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSerie", new { id = serie.Serieid }, serie);
        }

        // DELETE: api/Series/5
        [HttpDelete("{id}")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        /// <summary>
        /// Get a serie by his id.
        /// </summary>
        /// <returns>Http response</returns>
        /// <param name="id">The id of the serie</param>
        /// <response code="201">When the series is deleted</response>
        /// <response code="404">When the series is not funded</response>
        public async Task<IActionResult> DeleteSerie(int id)
        {
            var serie = await _context.Series.FindAsync(id);
            if (serie == null)
            {
                return NotFound();
            }

            _context.Series.Remove(serie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SerieExists(int id)
        {
            return _context.Series.Any(e => e.Serieid == id);
        }
    }
}
