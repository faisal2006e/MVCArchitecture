using Product.Core;
using Product.Models.Dtos;
using Product.Repository.IRepository;
using Product.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Repository
{
    public class ProductRepository : IProductRepository
    {
        private ProductDBEntities _db;
        public ProductRepository()
        {
            _db = new ProductDBEntities();
        }

        public Product AddProduct(Product product)
        {
            _db.Products.Add(product);
            _db.SaveChanges();

            return product;

        }

        public bool DeleteProduct(int productId)
        {
            var getProduct = _db.Products.Where(x => x.Id == productId).FirstOrDefault<Product>();
            if (getProduct != null)
            {
                _db.Products.Remove(getProduct);
                _db.SaveChanges();
                return true;
            }
            return false;
        }

        public Product EditProduct(Product product)
        {
            var oldProduct = _db.Products.FirstOrDefault(e => e.Id == product.Id);

            oldProduct.ProductGroupId = product.ProductGroupId;
            oldProduct.ProductDescription = product.ProductDescription;
            oldProduct.ProductNumber = product.ProductNumber;
            oldProduct.Price = product.Price;
            oldProduct.Active = product.Active;

            _db.SaveChanges();

            return product;
        }

        public List<Product> GetAllProduct()
        {
            //using (var dbContext = new DBModel(CommonDeclarations.DBContextConnectionString))
            //{
            //    return dbContext.Products.ToList();
            //}
            return _db.Products.ToList<Product>();
        }

        public Product GetProductById(int productId)
        {
            return _db.Products.Where(x => x.Id == productId).FirstOrDefault<Product>();
        }

        public Product GetProductByNumber(string productNumber)
        {
            return _db.Products.Where(x => x.ProductNumber == productNumber).FirstOrDefault<Product>();
        }
    }
}
