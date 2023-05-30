using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Qimt2.Pages
{
    [Authorize]
    public class PanalModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
