using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeLib.Pages;

public class Troubles : PageModel
{
    public int OriginalStatusCode { get; set; }

    public string? OriginalPathAndQuery { get; set; }

    public void OnGet(int statusCode)
    {
        OriginalStatusCode = statusCode;

        var statusCodeReExecuteFeature = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();

        if (statusCodeReExecuteFeature is not null)
        {
            OriginalPathAndQuery =
                $"{statusCodeReExecuteFeature.OriginalPathBase}"
                + $"{statusCodeReExecuteFeature.OriginalPath}"
                + $"{statusCodeReExecuteFeature.OriginalQueryString}";
        }
    }
}
