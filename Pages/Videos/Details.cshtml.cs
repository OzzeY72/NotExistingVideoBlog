using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NotExistingVideoBlog.Data;
using NotExistingVideoBlog.Models;

namespace NotExistingVideoBlog.Pages.Videos
{
    public class DetailsModel : PageModel
    {
        private readonly NotExistingVideoBlog.Data.ApplicationDbContext _context;

        public DetailsModel(NotExistingVideoBlog.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Video Video { get; set; } = default!; 
      public Author Author {get;set;} = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Video == null)
            {
                return NotFound();
            }

            var video = await _context.Video.FirstOrDefaultAsync(m => m.Id == id);
            
            if (video == null)
            {
                return NotFound();
            }
            else 
            {
                Video = video;
                var author = await _context.Author.FirstOrDefaultAsync(m=> m.Id == Video.AuthorId);
                if(author != null) Author = author;
            }
            return Page();
        }
    }
}
