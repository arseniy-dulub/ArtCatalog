using GEOArchive.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace GEOArchive.Db
{
    public class ArchiveContext : DbContext
    {
        public DbSet<GeoProject> Projects { get; set; }
        public DbSet<GeoFile> GeoFiles { get; set; }
    }
}
