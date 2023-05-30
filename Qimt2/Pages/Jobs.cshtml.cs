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
    public class JobsModel : PageModel
    {
        private readonly Qimt2.Data.ApplicationDbContext _context;

        public JobsModel(Qimt2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Jobs> Jobs { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Jobs != null)
            {
                Jobs = await _context.Jobs.ToListAsync();
            }
        }
    }
}
