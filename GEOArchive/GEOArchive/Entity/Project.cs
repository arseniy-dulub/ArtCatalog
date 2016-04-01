using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEOArchive.Entity
{
    public class GeoProject
    {
        public int GeoProjectId { get; set; }
        public string GeoProjectNum { get; set; }
        public string GeoProjectName { get; set; }
        public string GeoProjectPerformer { get; set; }
        public string GeoProjectCreateDate { get; set; }
        public string GeoProjectDescription { get; set; }
        public DateTime GeoProjectDateCreate { get; set; }

        public virtual List<GeoFile> GeoFiles { get; set; }
    }

    public class GeoFile
    {
        public int GeoFileId { get; set; }
        public string GeoFileType { get; set; }
        public string GeoFilePath { get; set; }
        public DateTime GeoFileDateCreate { get; set; }

        public int GeoProjectId { get; set; }
        public virtual GeoProject Project { get; set; }
    }
}
