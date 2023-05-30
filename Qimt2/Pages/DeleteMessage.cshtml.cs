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
    public class DeleteMessageModel : PageModel
    {
        private readonly Qimt2.Data.ApplicationDbContext _context;

        public DeleteMessageModel(Qimt2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Contactus Contactus { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Contacts == null)
            {
                return NotFound();
            }

            var contactus = await _context.Contacts.FirstOrDefaultAsync(m => m.Id == id);

            if (contactus == null)
            {
                return NotFound();
            }
            else 
            {
                Contactus = contactus;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Contacts == null)
            {
                return NotFound();
            }
            var contactus = await _context.Contacts.FindAsync(id);

            if (contactus != null)
            {
                Contactus = contactus;
                _context.Contacts.Remove(Contactus);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Messages");
        }
    }
}
