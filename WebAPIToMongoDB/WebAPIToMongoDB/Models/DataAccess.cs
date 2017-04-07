using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System.Collections.Generic;

namespace WebAPIToMongoDB.Models
{
    public class DataAccess
    {
        MongoClient _client;
        MongoServer _server;
        MongoDatabase _db;

        public DataAccess()
        {
            _client = new MongoClient("mongodb://localhost:27017");
            _server = _client.GetServer();
            _db = _server.GetDatabase("CatalogueDB");
        }

        
        /* Category methods */

        public IEnumerable<Category> GetCategories()
        {
            return _db.GetCollection<Category>("Categories").FindAll();
        }


        public Category GetCategory(string id)
        {
            var res = Query<Category>.EQ(c => c.Id, id);
            return _db.GetCollection<Category>("Categories").FindOne(res);
        }

        public Category CreateCategory(Category c)
        {
            _db.GetCollection<Category>("Categories").Save(c);
            return c;
        }

        public void UpdateCategory(string id, Category c)
        {
            c.Id = id;
            var res = Query<Category>.EQ(pd => pd.Id, id);
            var operation = Update<Category>.Replace(c);
            _db.GetCollection<Category>("Categories").Update(res, operation);
        }
        public void RemoveCategory(string id)
        {
            var res = Query<Category>.EQ(e => e.Id, id);
            var operation = _db.GetCollection<Category>("Categories").Remove(res);
        }






        /* SubCategory methods */

        public IEnumerable<SubCategory> GetSubCategories()
        {
            return _db.GetCollection<SubCategory>("SubCategories").FindAll();
        }


        public SubCategory GetSubCategory(string id)
        {
            var res = Query<SubCategory>.EQ(sc => sc.Id, id);
            return _db.GetCollection<SubCategory>("SubCategories").FindOne(res);
        }

        public SubCategory CreateSubCategory(SubCategory sc)
        {
            _db.GetCollection<SubCategory>("SubCategories").Save(sc);
            return sc;
        }

        public void UpdateSubCategory(string id, SubCategory sc)
        {
            sc.Id = id;
            var res = Query<SubCategory>.EQ(c => c.Id, id);
            var operation = Update<SubCategory>.Replace(sc);
            _db.GetCollection<SubCategory>("SubCategories").Update(res, operation);
        }
        public void RemoveSubCategory(string id)
        {
            var res = Query<SubCategory>.EQ(e => e.Id, id);
            var operation = _db.GetCollection<SubCategory>("SubCategories").Remove(res);
        }




        
        /* Product methods */

        public IEnumerable<Product> GetProducts()
        {
            return _db.GetCollection<Product>("Products").FindAll();
        }


        public Product GetProduct(string id)
        {
            var res = Query<Product>.EQ(p => p.Id, id);
            return _db.GetCollection<Product>("Products").FindOne(res);
        }

        public Product CreateProduct(Product p)
        {
            _db.GetCollection<Product>("Products").Save(p);
            return p;
        }

        public void UpdateProduct(string id, Product p)
        {
            p.Id = id;
            var res = Query<Product>.EQ(pd => pd.Id, id);
            var operation = Update<Product>.Replace(p);
            _db.GetCollection<Product>("Products").Update(res, operation);
        }
        public void RemoveProduct(string id)
        {
            var res = Query<Product>.EQ(e => e.Id, id);
            var operation = _db.GetCollection<Product>("Products").Remove(res);
        }
    }
}