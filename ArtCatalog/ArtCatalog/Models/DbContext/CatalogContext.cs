using ArtCatalog.Areas.Admin.Models;
using System.Data.Entity;

namespace ArtCatalog.Models.DbContext
{
    public class CatalogContext : System.Data.Entity.DbContext
    {
        public CatalogContext() : base("name=CatalogContext") { }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
