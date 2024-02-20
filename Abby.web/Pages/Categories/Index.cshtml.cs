using Abby.web.Data;
using Abby.web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Abby.web.Pages.Categories
{
    
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        [BindProperty]
        public IEnumerable<Category> Categories { get; set; }
        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        
        public void OnGet(int id)
        {
            Categories = _context.Categories;
        }

        public async Task<IActionResult> OnPost(int id)
        {
            var CategoryToDelete = _context.Categories.FindAsync(id);
            if (CategoryToDelete != null)
            {
                _context.Remove(CategoryToDelete);
                await _context.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
