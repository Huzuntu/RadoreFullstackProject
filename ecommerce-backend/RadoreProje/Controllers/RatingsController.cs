using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RadoreProje.Models;
using RadoreProje.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using RadoreProje.Dto;

namespace RadoreProje.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RatingsController : ControllerBase
    {
        private readonly RatingService _ratingService;
        private readonly IMapper _mapper;

        public RatingsController(RatingService ratingService, IMapper mapper)
        {
            _ratingService = ratingService;
            _mapper = mapper;
        }

        // GET: api/ratings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RatingDto>>> GetRatings()
        {
            var ratings = await _ratingService.GetAllRatingsAsync();
            return Ok(ratings);
        }

        // GET: api/ratings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RatingDto>> GetRating(int id)
        {
            var rating = await _ratingService.GetRatingByIdAsync(id);
            if (rating == null)
            {
                return NotFound();
            }
            return Ok(rating);
        }

        // POST: api/ratings
        [HttpPost]
        public async Task<ActionResult<RatingDto>> CreateRating(RatingDto ratingDto)
        {
            var createdRating = await _ratingService.CreateRatingAsync(ratingDto);
            return CreatedAtAction(nameof(GetRating), new { id = createdRating.Id }, createdRating);
        }

        // PUT: api/ratings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRating(int id, RatingDto ratingDto)
        {
            if (id != ratingDto.Id)
            {
                return BadRequest();
            }

            var updated = await _ratingService.UpdateRatingAsync(ratingDto);
            if (!updated)
            {
                return NotFound();
            }
            return NoContent();
        }

        // DELETE: api/ratings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRating(int id)
        {
            var deleted = await _ratingService.DeleteRatingAsync(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}