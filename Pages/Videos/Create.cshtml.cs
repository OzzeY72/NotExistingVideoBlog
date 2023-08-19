using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NotExistingVideoBlog.Data;
using NotExistingVideoBlog.Models;

namespace NotExistingVideoBlog.Pages.Videos
{
    public class CreateModel : PageModel
    {
        private readonly NotExistingVideoBlog.Data.ApplicationDbContext _context;

        public CreateModel(NotExistingVideoBlog.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["AuthorId"] = new SelectList(_context.Author, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Video Video { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Video == null || Video == null)
            {
                return Page();
            }

            _context.Video.Add(Video);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
