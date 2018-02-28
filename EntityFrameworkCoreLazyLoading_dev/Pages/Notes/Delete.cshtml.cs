using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EntityFrameworkCoreLazyLoading_dev.Data;

namespace EntityFrameworkCoreLazyLoading_dev.Pages.Notes
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Note Note { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Note = await _context.Note
                .Include(n => n.Category).FirstOrDefaultAsync(m => m.Id == id);

            if (Note == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Note = await _context.Note.FindAsync(id);

            if (Note != null)
            {
                _context.Note.Remove(Note);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
