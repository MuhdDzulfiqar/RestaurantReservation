using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Server.Data;
using RestaurantReservation.Shared.Domain;

namespace RestaurantReservation.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CertificationsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CertificationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Certifications
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Certification>>> GetCertifications()
        {
            return await _context.Certifications.ToListAsync();
        }

        // GET: api/Certifications/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Certification>> GetCertification(int id)
        {
            var certification = await _context.Certifications.FindAsync(id);

            if (certification == null)
            {
                return NotFound();
            }

            return certification;
        }

        // PUT: api/Certifications/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCertification(int id, Certification certification)
        {
            if (id != certification.Id)
            {
                return BadRequest();
            }

            _context.Entry(certification).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CertificationExists(id))
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

        // POST: api/Certifications
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Certification>> PostCertification(Certification certification)
        {
            _context.Certifications.Add(certification);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCertification", new { id = certification.Id }, certification);
        }

        // DELETE: api/Certifications/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCertification(int id)
        {
            var certification = await _context.Certifications.FindAsync(id);
            if (certification == null)
            {
                return NotFound();
            }

            _context.Certifications.Remove(certification);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CertificationExists(int id)
        {
            return _context.Certifications.Any(e => e.Id == id);
        }
    }
}
