using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Server.Data;
using RestaurantReservation.Server.IRepository;
using RestaurantReservation.Shared.Domain;

namespace RestaurantReservation.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromotionsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public PromotionsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Promotions
        [HttpGet]
        public async Task<IActionResult> GetPromotions()
        {
            var promotions = await _unitOfWork.Promotions.GetAll();
            return Ok(promotions);
        }

        // GET: api/Promotions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPromotion(int id)
        {
            var promotion = await _unitOfWork.Promotions.Get(q => q.Id == id);

            if (promotion == null)
            {
                return NotFound();
            }

            return Ok(promotion);
        }

        // PUT: api/Promotions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPromotion(int id, Promotion promotion)
        {
            if (id != promotion.Id)
            {
                return BadRequest();
            }

            _unitOfWork.Promotions.Update(promotion);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await PromotionExists(id))
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

        // POST: api/Promotions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Promotion>> PostPromotion(Promotion promotion)
        {
            await _unitOfWork.Promotions.Insert(promotion);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetPromotion", new { id = promotion.Id }, promotion);
        }

        // DELETE: api/Promotions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePromotion(int id)
        {
            var promotion = await _unitOfWork.Promotions.Get(q => q.Id == id);
            if (promotion == null)
            {
                return NotFound();
            }

            await _unitOfWork.Promotions.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> PromotionExists(int id)
        {
            var promotion = await _unitOfWork.Promotions.Get(q => q.Id == id);
            return promotion != null;
        }
    }
}
