using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ArtCatalog.Models.DbContext
{
    public class CatalogContext : System.Data.Entity.DbContext
    {
        public CatalogContext() : base("name=CatalogContext") { }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }
    }
}
