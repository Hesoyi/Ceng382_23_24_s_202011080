using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyRazorPagesApp.Data;
using MyRazorPagesApp.Model;
using System.Threading.Tasks;

namespace MyRazorPagesApp.Pages
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _context;

        public CreateModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Room Room { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Rooms.Add(Room);
            await _context.SaveChangesAsync();
            return RedirectToPage("/Rooms/Index"); // Oda oluşturulduktan sonra Rooms/Index sayfasına yönlendirme
        }
    }
}
