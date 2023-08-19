using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NotExistingVideoBlog.Data;
using NotExistingVideoBlog.Models;

namespace NotExistingVideoBlog.Pages.Videos
{
    public class EditModel : PageModel
    {
        private readonly NotExistingVideoBlog.Data.ApplicationDbContext _context;

        public EditModel(NotExistingVideoBlog.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Video Video { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Video == null)
            {
                return NotFound();
            }

            var video =  await _context.Video.FirstOrDefaultAsync(m => m.Id == id);
            if (video == null)
            {
                return NotFound();
            }
            Video = video;
           ViewData["AuthorId"] = new SelectList(_context.Author, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Video).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VideoExists(Video.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool VideoExists(int id)
        {
          return (_context.Video?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
