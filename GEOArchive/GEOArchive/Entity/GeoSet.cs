using System.Collections.Generic;

namespace GEOArchive.Entity
{
    public class GeoSet
    {
        public int GeoSetId { get; set; }
        public string GeoSetNum { get; set; }
        public string GeoSetName { get; set; }
        public string GeoSetCreator { get; set; }
        public string GeoSetDateCreate { get; set; }
        public virtual List<GeoFile> Files { get; set; }
        public string Description { get; set; }
    }

    public class GeoFile
    {
        public int GeoFileId { get; set; }
        public string GeoFileType { get; set; }
        public string GeoFilePath { get; set; }
        public string GeoFileDateCreate { get; set; }
        public virtual int GeoSetId { get; set; }
    }
}
