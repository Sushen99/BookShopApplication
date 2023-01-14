using BookShopWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BookShopWeb.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option)
        {
        }
        public DbSet<Category> Categories { get; set; }
    }
}
