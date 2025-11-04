using Microsoft.AspNetCore.Mvc.RazorPages;
using OmnibusUI.Data;
using OmnibusUI.Models;
using Microsoft.EntityFrameworkCore;

namespace OmnibusUI.Pages.Patron
{
    public class IndexModel(AppDbContext context) : PageModel
    {
        private readonly AppDbContext _context = context;

        public IList<OmnibusUI.Models.Patron>? Patrons { get; set; }

        public async Task OnGetAsync()
        {
            //Patrons = await _context.Patrons.ToListAsync(); //retrieves all 250 causes timeout b/c large data
            Patrons = await _context.Patrons.Take(10).ToListAsync();

        }
    }
}


//namespace OmnibusUI.Pages.Patron
//{
//    public class IndexModel : PageModel
//    {
//        private readonly AppDbContext _context;
//        public IndexModel(AppDbContext context)
//        {
//            _context = context;
//        }
//        public IList<OmnibusUI.Models.Patron> Patrons { get; set; }
//        public async Task OnGetAsync()
//        {
//            Patrons = await _context.Patrons.ToListAsync();
//        }
//    }
//}
