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
    public class CreateModel : PageModel
    {
        private readonly OmnibusUI.Data.AppDbContext _context;
        public IList<OmnibusUI.Models.Patron> Patrons { get; set; } = default!;

        public CreateModel(OmnibusUI.Data.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public OmnibusUI.Models.Patron Patron { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            Patrons = await _context.Patrons.ToListAsync();
            Patron.patronID = Patrons.Count + 1;
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Patrons.Add(Patron);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
