using Product.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Services.IServices
{
    public interface IProductServices
    {
        ProductDto AddProduct(ProductDto product);
        bool DeleteProduct(int productId);
        ProductDto EditProduct(ProductDto product);
        List<ProductDto> GetAllProduct();
        ProductDto GetProductById(int productId);

        ProductDto GetProductByNumber(string productNumber);
    }
    
}
