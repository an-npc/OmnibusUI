using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OmnibusUI.Data;
using OmnibusUI.Models;

namespace OmnibusUI.Pages.Patron
{
    public class DetailsModel : PageModel
    {
        private readonly OmnibusUI.Data.AppDbContext _context;

        public DetailsModel(OmnibusUI.Data.AppDbContext context)
        {
            _context = context;
        }

        public OmnibusUI.Models.Patron Patron { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patron = await _context.Patrons.FirstOrDefaultAsync(m => m.patronID == id);

            if (patron is not null)
            {
                Patron = patron;

                return Page();
            }

            return NotFound();
        }
    }
}
