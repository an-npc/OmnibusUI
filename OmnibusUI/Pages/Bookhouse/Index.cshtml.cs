using Microsoft.AspNetCore.Mvc.RazorPages;
using OmnibusUI.Data;
using OmnibusUI.Models;
using Microsoft.EntityFrameworkCore;

namespace OmnibusUI.Pages.Bookhouse
{
    public class IndexModel(AppDbContext context) : PageModel
    {
        private readonly AppDbContext _context = context;

        public IList<OmnibusUI.Models.Book>? Bookhouse { get; set; }

        public async Task OnGetAsync()
        {
            Bookhouse = await _context.Bookhouse.ToListAsync();
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
