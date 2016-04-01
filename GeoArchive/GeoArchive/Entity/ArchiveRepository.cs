
namespace GeoArchive.Entity
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Data.Entity;
    //using System.Data;
    using GeoArchive;
    using GeoArchive.Entity;

    public interface IArchiveRepository
    {
        IQueryable<GeoProject> All { get; }
        IQueryable<GeoProject> AllIncluding(params Expression<Func<GeoProject, object>>[] includeProperties);
        GeoProject Find(int id);
        void InsertOrUpdate(GeoProject geoproject);
        void Delete(int id);
        void Save();
    }
    
    public class ArchiveRepository : IArchiveRepository
    {
        private readonly ArchiveContext _context = new ArchiveContext();

        public IQueryable<GeoProject> All
        {
            get { return _context.GeoProjects; }
        }

        public IQueryable<GeoProject> AllIncluding(params Expression<Func<GeoProject, object>>[] includeProperties)
        {
            IQueryable<GeoProject> query = _context.GeoProjects;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public GeoProject Find(int id)
        {
            return _context.GeoProjects.Find(id);
        }

        public void InsertOrUpdate(GeoProject geoproject)
        {
            if (geoproject.Id == default(int))
            {
                _context.GeoProjects.Add(geoproject); 
            }
            else
            {
                _context.Entry(geoproject).State = EntityState.Modified;             
            }
        }

        public void Delete(int id)
        {
            var geoproject = _context.GeoProjects.Find(id);
            _context.GeoProjects.Remove(geoproject);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
