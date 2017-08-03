using MongoDB.Bson;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab.MongoDBApps.Models
{
    public class ProductRepository : IProductRepository
    {

        #region Private Variable
        private readonly MongoDbContext _mongoDbContext;
        #endregion

        #region Constructor
        public ProductRepository()
        {
            _mongoDbContext = new MongoDbContext();
        }

        #endregion

        #region Method

        public Product Insert(Product entity)
        {
            _mongoDbContext.Product.Save(entity);
            return entity;
        }
        
        public Product Update(Product entity)
        {
            var model = Query<Product>.EQ(pd => pd.Id, entity.Id);
            var operation = Update<Product>.Replace(entity);
            _mongoDbContext.Product.Update(model, operation);
            return entity;
        }

        public Product Get(ObjectId id)
        {
            var model = Query<Product>.EQ(p => p.Id, id);
            return _mongoDbContext.Product.FindOne(model);
        }

        public IEnumerable<Product> GetAll()
        {
            return _mongoDbContext.Product.FindAll();
        }
        
        public void Delete(Product entity)
        {
            var model = Query<Product>.EQ(e => e.Id, entity.Id);
            var operation = _mongoDbContext.Product.Remove(model);
        }

        #endregion
    }

    public interface IProductRepository
    {
        Product Insert(Product entity);
        Product Update(Product entity);
        void Delete(Product entity);
        Product Get(ObjectId id);
        IEnumerable<Product> GetAll();
    }
}