using Microsoft.EntityFrameworkCore;
using Survive.Api.Library.Products.Entities;

namespace Survive.Api.Database
{
    public class MainDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options) { }
    }
}
