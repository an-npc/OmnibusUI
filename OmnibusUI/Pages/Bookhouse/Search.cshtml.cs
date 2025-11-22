using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OmnibusUI.Data;
using OmnibusUI.Models;
using static System.Reflection.Metadata.BlobBuilder;

namespace OmnibusUI.Pages.Bookhouse
{
    public class SearchModel : PageModel
    {
        private readonly AppDbContext _context;

        public SearchModel(AppDbContext context)
        {
            _context = context;
        }

        public IList<Book> Book { get; set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string Search { get; set; }

        public async Task OnGetAsync()
        {
            var query = _context.Bookhouse.AsQueryable();

            if (!string.IsNullOrEmpty(Search))
            {
                query = query.Where(b => b.title.Contains(Search));
            }

            Book = await query.ToListAsync();
        }
    }
}