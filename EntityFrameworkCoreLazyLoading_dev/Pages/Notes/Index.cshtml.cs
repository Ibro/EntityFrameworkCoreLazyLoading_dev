using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EntityFrameworkCoreLazyLoading_dev.Data;

namespace EntityFrameworkCoreLazyLoading_dev.Pages.Notes
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Note> Note { get;set; }

        public async Task OnGetAsync()
        {
            Note = await _context.Note
                .Include(n => n.Category).ToListAsync();
        }
    }
}
