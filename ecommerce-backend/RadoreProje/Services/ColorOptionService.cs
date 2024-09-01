using Microsoft.EntityFrameworkCore;
using RadoreProje.Data;
using RadoreProje.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadoreProje.Services
{
    public class ColorOptionService
    {
        private readonly ApplicationDbContext _context;

        public ColorOptionService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ColorOption>> GetAllColorOptionsAsync()
        {
            return await _context.ColorOptions.ToListAsync();
        }

        public async Task<ColorOption> GetColorOptionByIdAsync(int id)
        {
            return await _context.ColorOptions.FindAsync(id);
        }

        public async Task<ColorOption> CreateColorOptionAsync(ColorOption colorOption)
        {
            _context.ColorOptions.Add(colorOption);
            await _context.SaveChangesAsync();
            return colorOption;
        }

        public async Task<bool> UpdateColorOptionAsync(ColorOption colorOption)
        {
            _context.Entry(colorOption).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ColorOptionExists(colorOption.Id))
                {
                    return false;
                }
                throw;
            }
        }

        public async Task<bool> DeleteColorOptionAsync(int id)
        {
            var colorOption = await _context.ColorOptions.FindAsync(id);
            if (colorOption == null)
            {
                return false;
            }

            _context.ColorOptions.Remove(colorOption);
            await _context.SaveChangesAsync();
            return true;
        }

        private bool ColorOptionExists(int id)
        {
            return _context.ColorOptions.Any(e => e.Id == id);
        }
    }
}