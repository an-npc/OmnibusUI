using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OmnibusUI.Data;
using OmnibusUI.Models;

namespace OmnibusUI.Pages.Patron
{
    public class EditModel : PageModel
    {
        private readonly OmnibusUI.Data.AppDbContext _context;

        public EditModel(OmnibusUI.Data.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public OmnibusUI.Models.Patron Patron { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patron =  await _context.Patrons.FirstOrDefaultAsync(m => m.patronID == id);
            if (patron == null)
            {
                return NotFound();
            }
            Patron = patron;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Patron).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatronExists(Patron.patronID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PatronExists(int id)
        {
            return _context.Patrons.Any(e => e.patronID == id);
        }
    }
}
