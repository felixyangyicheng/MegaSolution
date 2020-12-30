using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaSolution.Electron.Pages
{
    public class HostModel : PageModel
    {
        private readonly AppData appData;

        public HostModel(AppData appData)
        {
            this.appData = appData;
        }
        public void OnGet()
        {
            var theme = HttpContext.Request.Cookies["theme"];
            if (string.IsNullOrEmpty(theme))
            {
                theme = "Léger";
            }
            appData.Theme = theme;
        }
    }
}
