using BookShop.Model;
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
        public DbSet<CoverType> CoverTypes{ get; set; }
    }
}
