using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EntityFrameworkCoreLazyLoading_dev.Data;

namespace EntityFrameworkCoreLazyLoading_dev.Pages.Notes
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public Note Note { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Note = await _context.Note.FirstOrDefaultAsync(m => m.Id == id);

            if (Note == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
