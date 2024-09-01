using Microsoft.AspNetCore.Mvc;
using RadoreProje.Models;
using RadoreProje.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using RadoreProje.Dto;
using RadoreProje.Data;

namespace RadoreProje.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorOptionsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ColorOptionsController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/ColorOptions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ColorOptionDto>>> GetColorOptions()
        {
            var colorOptions = await _context.ColorOptions.ToListAsync();
            var colorOptionsDto = _mapper.Map<IEnumerable<ColorOptionDto>>(colorOptions);
            return Ok(colorOptionsDto);
        }

        // GET: api/ColorOptions/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ColorOptionDto>> GetColorOption(int id)
        {
            var colorOption = await _context.ColorOptions.FindAsync(id);

            if (colorOption == null)
            {
                return NotFound();
            }

            var colorOptionDto = _mapper.Map<ColorOptionDto>(colorOption);
            return Ok(colorOptionDto);
        }

        // POST: api/ColorOptions
        [HttpPost]
        public async Task<ActionResult<ColorOptionDto>> PostColorOption(ColorOptionDto colorOptionDto)
        {
            var colorOption = _mapper.Map<ColorOption>(colorOptionDto);

            _context.ColorOptions.Add(colorOption);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetColorOption), new { id = colorOption.Id }, colorOptionDto);
        }

        // PUT: api/ColorOptions/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutColorOption(int id, ColorOptionDto colorOptionDto)
        {
            if (id != colorOptionDto.Id)
            {
                return BadRequest();
            }

            var colorOption = _mapper.Map<ColorOption>(colorOptionDto);
            _context.Entry(colorOption).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ColorOptionExists(id))
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

        // DELETE: api/ColorOptions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteColorOption(int id)
        {
            var colorOption = await _context.ColorOptions.FindAsync(id);
            if (colorOption == null)
            {
                return NotFound();
            }

            _context.ColorOptions.Remove(colorOption);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ColorOptionExists(int id)
        {
            return _context.ColorOptions.Any(e => e.Id == id);
        }
    }
}


