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
    public class CreateReportModel : PageModel
    {
        private readonly Qimt2.Data.ApplicationDbContext _context;

        public CreateReportModel(Qimt2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Report Report { get; set; } = default!;
        

        
        public async Task<IActionResult> OnPostAsync()
        {
            //var photoname = "";
            if (Report.file != null)
            {
                var dd = DateTime.Now;
                var xc = $"{dd.Year}{dd.Month}{dd.Day}{dd.Hour}{dd.Minute}{dd.Second}{Path.GetExtension(Report.file.FileName)}";
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", xc);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    Report.file.CopyTo(stream);
                    Report.Photo = xc;
                }
            }
            if (!ModelState.IsValid || _context.Reports == null || Report == null)
            {
                return Page();
            }
           

            _context.Reports.Add(Report);
            await _context.SaveChangesAsync();

            return RedirectToPage("./home");
        }
    }
}
