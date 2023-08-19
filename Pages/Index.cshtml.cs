﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NotExistingVideoBlog.Data;
using NotExistingVideoBlog.Models;

namespace NotExistingVideoBlog.Pages
{
    public class IndexModel : PageModel
    {
        private readonly NotExistingVideoBlog.Data.ApplicationDbContext _context;

        public IndexModel(NotExistingVideoBlog.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        public IList<Video> Video { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Video != null)
            {
                Video = await _context.Video
                .Include(v => v.Author).ToListAsync();
            }
        }
    }
}
