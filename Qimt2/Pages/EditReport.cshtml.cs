using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Qimt2.Data;

namespace Qimt2.Pages
{
    [Authorize]
    public class EditReportModel : PageModel
    {
        private readonly Qimt2.Data.ApplicationDbContext _context;

        public EditReportModel(Qimt2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Report Report { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Reports == null)
            {
                return NotFound();
            }

            var report =  await _context.Reports.FirstOrDefaultAsync(m => m.RepId == id);
            if (report == null)
            {
                return NotFound();
            }
            Report = report;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
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
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Report).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReportExists(Report.RepId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Report");
        }

        private bool ReportExists(int id)
        {
          return (_context.Reports?.Any(e => e.RepId == id)).GetValueOrDefault();
        }
    }
}
