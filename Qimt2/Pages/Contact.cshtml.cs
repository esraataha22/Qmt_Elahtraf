using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Qimt2.Data;

namespace Qimt2.Pages
{
    public class ContactModel : PageModel
    {
        private readonly Qimt2.Data.ApplicationDbContext _context;

        public ContactModel(Qimt2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Contactus Contactus { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Contacts == null || Contactus == null)
            {
                return Page();
            }

           _context.Contacts.Add(Contactus);
            await _context.SaveChangesAsync();

            return RedirectToPage("./home");
        }
    }
}
