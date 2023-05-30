using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Qimt2.Data;

namespace Qimt2.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly Qimt2.Data.ApplicationDbContext _context;

        public DetailsModel(Qimt2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
