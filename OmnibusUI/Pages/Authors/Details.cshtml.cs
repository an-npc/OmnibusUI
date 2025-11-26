using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OmnibusUI.Data;
using OmnibusUI.Models;

namespace OmnibusUI.Pages.Authors
{
    public class DetailsModel : PageModel
    {
        private readonly OmnibusUI.Data.AppDbContext _context;

        public DetailsModel(OmnibusUI.Data.AppDbContext context)
        {
            _context = context;
        }

        public Author Author { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var author = await _context.Authors.FirstOrDefaultAsync(m => m.authID == id);

            if (author is not null)
            {
                Author = author;

                return Page();
            }

            return NotFound();
        }
    }
}
