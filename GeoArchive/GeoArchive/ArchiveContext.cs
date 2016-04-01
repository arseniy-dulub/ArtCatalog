
namespace GeoArchive
{
    using System.Data.Entity;
    using GeoArchive.Entity;

    public class ArchiveContext : DbContext
    {
        public DbSet<GeoProject> GeoProjects { get; set; }
    }
}
