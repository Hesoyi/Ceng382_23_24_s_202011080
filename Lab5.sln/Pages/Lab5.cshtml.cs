using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyApp.Namespace
{
    public class Lab5Model : PageModel
    {
    private readonly ILogger<Lab5Model> _logger;

    public Lab5Model(ILogger<Lab5Model> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }
    }
}
