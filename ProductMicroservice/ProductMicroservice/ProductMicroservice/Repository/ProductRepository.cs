using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductMicroservice.Models;
using Microsoft.EntityFrameworkCore;
using ProductMicroservice.DBContexts;

namespace ProductMicroservice.Repository
{
    public class ProductRepository : IProductRepository
    {
        readonly ProductContext _Dbcontext;

        public ProductRepository(ProductContext dbContext)
        {
            _Dbcontext = dbContext;
        }
        public void DeleteProduct(int ProductId)
        {
            var product = _Dbcontext.Product.Find(ProductId);
            _Dbcontext.Product.Remove(product);
            Save();
        }

        public Product GetProductByID(int ProductId)
        {
            return _Dbcontext.Product.Find(ProductId);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _Dbcontext.Product.ToList();
        }

        public void InsertProduct(Product product)
        {
            _Dbcontext.Product.Add(product);
            Save();
        }

        public void Save()
        {
            _Dbcontext.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            _Dbcontext.Entry(product).State = EntityState.Modified;
            Save();
        }
    }
}
