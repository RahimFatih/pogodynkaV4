using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace pogodynkaV4.Pages_Weather
{
    public class CreateModel : PageModel
    {

        private readonly RazorPagesGameContext _context;

        public CreateModel(RazorPagesGameContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }
        [BindProperty]
        public Weather Weather { get; set; }
        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Weather.newEntry(Weather.name);
            _context.Weather.Add(Weather);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
