using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace pogodynkaV4.Pages_Weather
{
    public class DeleteModel : PageModel
    {
        private readonly RazorPagesGameContext _context;

        public DeleteModel(RazorPagesGameContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Weather Weather { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Weather = await _context.Weather.FirstOrDefaultAsync(m => m.ID == id);

            if (Weather == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Weather = await _context.Weather.FindAsync(id);

            if (Weather != null)
            {
                _context.Weather.Remove(Weather);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
