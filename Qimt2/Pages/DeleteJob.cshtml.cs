using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Qimt2.Data;

namespace Qimt2.Pages
{
    [Authorize]
    public class DeleteJobModel : PageModel
    {
        private readonly Qimt2.Data.ApplicationDbContext _context;

        public DeleteJobModel(Qimt2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Jobs Jobs { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Jobs == null)
            {
                return NotFound();
            }

            var jobs = await _context.Jobs.FirstOrDefaultAsync(m => m.Id == id);

            if (jobs == null)
            {
                return NotFound();
            }
            else 
            {
                Jobs = jobs;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Jobs == null)
            {
                return NotFound();
            }
            var jobs = await _context.Jobs.FindAsync(id);

            if (jobs != null)
            {
                Jobs = jobs;
                _context.Jobs.Remove(Jobs);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Jobs");
        }
    }
}
