using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNet.Apple.Web.Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace AspNet.Apple.Web.Razor.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly AppSettings _appSettings;

        public IndexModel(ILogger<IndexModel> logger, IOptions<AppSettings> appSettings)
        {
            _logger = logger;
            _appSettings = appSettings.Value;
        }

        [BindProperty(SupportsGet = true)]
        public AppSettings AppSettings { get; set; }
        public void OnGet()
        {
            AppSettings.ClientId = _appSettings.ClientId;
            AppSettings.RedirectUri = _appSettings.RedirectUri;
        }
    }
}
