using Product.Models.Dtos;
using Product.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Repository.IRepository
{
    public interface IProductRepository
    {
        Product AddProduct(Product product);
        bool DeleteProduct(int productId);
        Product EditProduct(Product product);
        List<Product> GetAllProduct();
        Product GetProductById(int productId);
        Product GetProductByNumber(string productNumber);
    }
}
