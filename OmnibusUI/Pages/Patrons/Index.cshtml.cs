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
    public class IndexModel : PageModel
    {
        private readonly OmnibusUI.Data.AppDbContext _context;

        public IndexModel(OmnibusUI.Data.AppDbContext context)
        {
            _context = context;
        }

        public IList<Patron> Patron { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Patron = await _context.Patrons.ToListAsync();
        }
    }
}
