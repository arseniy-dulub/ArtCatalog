using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ArtCatalog.Models.DbContext;
using System.Data.Entity;
using System.Data;

namespace ArtCatalog.Models.Repositories
{
    public interface ICategoryRepository
    {
        IQueryable<Category> All { get; }
        IQueryable<Category> AllIncluding(params Expression<Func<Category, object>>[] includeProperties);
        Category Find(int id);
        void InsertOrUpdate(Category category);
        void Delete(int id);
        void Save();
    }

    public class CategoryRepository : ICategoryRepository
    {
        private readonly CatalogContext context = new CatalogContext();

        public IQueryable<Category> All
        {
            get { return context.Categories; }
        }

        public IQueryable<Category> AllIncluding(params Expression<Func<Category, object>>[] includeProperties)
        {
            IQueryable<Category> query = context.Categories;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Category Find(int id)
        {
            return context.Categories.Find(id);
        }

        public void InsertOrUpdate(Category category)
        {
            if (category.CategoryID == default(int))
            {
                context.Categories.Add(category);
            }
            else
            {
                context.Entry(category).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var category = context.Categories.Find(id);
            context.Categories.Remove(category);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}