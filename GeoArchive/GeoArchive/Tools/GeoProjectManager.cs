
namespace GeoArchive.Tools
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Data.Entity;
    using System.Data;
    using GeoArchive.Entity;
    using System.IO;
    using System.Windows.Forms;

    public class GeoProjectManager
    {
        private readonly IArchiveRepository _archiveRepository;

        private ArchiveContext db = new ArchiveContext();

        public GeoProjectManager() : this(new ArchiveRepository()) { }

        public GeoProjectManager(IArchiveRepository archiveRepository)
        {
            this._archiveRepository = archiveRepository;
        }

        public bool Create(string uploadFiles, string firstFile)
        {
            if (uploadFiles != string.Empty)
            {
                GeoProject newGeoProject = new GeoProject();
                newGeoProject.Name = FileManager.GetFileName(firstFile);
                newGeoProject.Files = uploadFiles;

                try
                {
                    db.GeoProjects.Add(newGeoProject);
                    db.SaveChanges();
                    return true;
                }
                catch { return false; }
                
            }
            else
            {
                return false;
            }
        }
    }
}
