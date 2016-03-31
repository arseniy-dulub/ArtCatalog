
namespace GEO_Archive
{
    using System.Data.Entity;
    using GEO_Archive.Entity;

    public class ArchiveContext : DbContext
    {
        public DbSet<GeoProject> GeoProjects { get; set; }
    }
}
