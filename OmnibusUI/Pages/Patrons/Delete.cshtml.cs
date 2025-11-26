using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OmnibusUI.Data;
using OmnibusUI.Models;

namespace OmnibusUI.Pages.Patrons
{
    public class DeleteModel : PageModel
    {
        private readonly OmnibusUI.Data.AppDbContext _context;

        public DeleteModel(OmnibusUI.Data.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Patron Patron { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patron = await _context.Patrons.FirstOrDefaultAsync(m => m.libCardNum == id);

            if (patron is not null)
            {
                Patron = patron;

                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patron = await _context.Patrons.FindAsync(id);
            if (patron != null)
            {
                Patron = patron;
                _context.Patrons.Remove(Patron);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
