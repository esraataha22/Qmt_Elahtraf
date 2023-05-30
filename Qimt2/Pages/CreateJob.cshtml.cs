using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Qimt2.Data;

namespace Qimt2.Pages
{
    [Authorize]

    public class CreateJobModel : PageModel
    {
        private readonly Qimt2.Data.ApplicationDbContext _context;

        public CreateJobModel(Qimt2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Jobs Jobs { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Jobs == null || Jobs == null)
            {
                return Page();
            }

            _context.Jobs.Add(Jobs);
            await _context.SaveChangesAsync();

            return RedirectToPage("./home");
        }
    }
}
