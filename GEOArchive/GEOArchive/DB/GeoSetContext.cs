using System.Data.Entity;
using GEOArchive.Entity;

namespace GEOArchive.DB
{
    public class GeoSetContext : DbContext
    {
        public DbSet<GeoSet> GeoSets { get; set; }
        public DbSet<GeoFile> GeoFiles { get; set; }
    }
}
