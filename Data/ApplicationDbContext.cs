using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NotExistingVideoBlog.Models;

namespace NotExistingVideoBlog.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<NotExistingVideoBlog.Models.Video>? Video { get; set; }
        public DbSet<NotExistingVideoBlog.Models.Author>? Author { get; set; }
    }
}