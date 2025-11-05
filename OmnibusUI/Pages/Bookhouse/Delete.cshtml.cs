using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OmnibusUI.Data;
using OmnibusUI.Models;

namespace OmnibusUI.Pages.Bookhouse
{
    public class DeleteModel : PageModel
    {
        private readonly OmnibusUI.Data.AppDbContext _context;

        public DeleteModel(OmnibusUI.Data.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Book Book { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Bookhouse.FirstOrDefaultAsync(m => m.bookID == id);

            if (book is not null)
            {
                Book = book;

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

            var book = await _context.Bookhouse.FindAsync(id);
            if (book != null)
            {
                Book = book;
                _context.Bookhouse.Remove(Book);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
