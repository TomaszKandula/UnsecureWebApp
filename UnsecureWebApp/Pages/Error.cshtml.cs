using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UnsecureWebApp.Pages
{
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public class ErrorModel : PageModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        private readonly ILogger<ErrorModel> FLogger;

        public ErrorModel(ILogger<ErrorModel> ALogger)
            => FLogger = ALogger;

        public void OnGet()
            => RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
    }
}
