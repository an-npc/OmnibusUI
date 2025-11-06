using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OmnibusUI.Data;
using OmnibusUI.Models;

namespace OmnibusUI.Pages.Tests
{
    public class DetailsModel : PageModel
    {
        private readonly OmnibusUI.Data.AppDbContext _context;

        public DetailsModel(OmnibusUI.Data.AppDbContext context)
        {
            _context = context;
        }

        public Test Test { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var test = await _context.Tests.FirstOrDefaultAsync(m => m.bookID == id);

            if (test is not null)
            {
                Test = test;

                return Page();
            }

            return NotFound();
        }
    }
}
