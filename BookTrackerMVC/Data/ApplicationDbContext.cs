using BookTrackerMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace BookTrackerMVC.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Book> Book { get; set; }
    }
}
