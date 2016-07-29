using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ArtCatalog.Models.DbContext;
using System.Data.Entity;
using System.Data;

namespace ArtCatalog.Models.Repositories
{
    public interface IProductRepository
    {
        IQueryable<Product> All { get; }
        IQueryable<Product> AllIncluding(params Expression<Func<Product, object>>[] includeProperties);
        Product Find(int id);
        void InsertOrUpdate(Product product);
        void Delete(int id);
        void Save();
    }

    public class ProductRepository : IProductRepository
    {
        private readonly CatalogContext context = new CatalogContext();

        public IQueryable<Product> All
        {
            get { return context.Products; }
        }

        public IQueryable<Product> AllIncluding(params Expression<Func<Product, object>>[] includeProperties)
        {
            IQueryable<Product> query = context.Products;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Product Find(int id)
        {
            return context.Products.Find(id);
        }

        public void InsertOrUpdate(Product product)
        {
            if (product.ProductID == default(int))
            {
                context.Products.Add(product);
            }
            else
            {
                context.Entry(product).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var product = context.Products.Find(id);
            context.Products.Remove(product);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}