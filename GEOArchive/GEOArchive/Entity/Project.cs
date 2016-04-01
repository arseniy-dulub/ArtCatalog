using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEOArchive.Entity
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string ProjectNum { get; set; }
        public string ProjectName { get; set; }
        public string ProjectPerformer { get; set; }
        public string ProjectCreateDate { get; set; }
        public string ProjectDescription { get; set; }
        public DateTime ProjectDateCreate { get; set; }

        public virtual List<GeoFile> GeoFiles { get; set; }
    }

    public class GeoFile
    {
        public int GeoFileId { get; set; }
        public string GeoFileType { get; set; }
        public string GeoFilePath { get; set; }
        public DateTime GeoFileDateCreate { get; set; }

        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }
    }
}
