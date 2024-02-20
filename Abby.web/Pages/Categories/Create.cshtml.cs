using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Abby.web.Data;
using Abby.web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Abby.web.Pages.Categories
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        
        public Category Category { get; set; }
        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost() {
            if(Category.Name == Category.DisplayOrder.ToString()) {
                ModelState.AddModelError(string.Empty, "The display order does not match the name!!");
            }
            if(ModelState.IsValid)
            {
                await _context.AddAsync(Category);
                await _context.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return Page();
        }

    }
}
