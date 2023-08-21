using Product.Models.Dtos;
using Product.Repository;
using Product.Repository.IRepository;
using Product.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Services.Services
{
    public class ProductService : IProductServices
    {
        private IProductRepository _productRepository;
        public ProductService()
        {
            _productRepository = new ProductRepository();
        }

        public ProductDto AddProduct(ProductDto product)
        {
            // TestingData.productList.Add(product)
            // ;
            ProductDto productdto = new ProductDto();
            Product.Repository.Product productData = new Product.Repository.Product();
            AutoMapper.Mapper.Map(product, productData);
            AutoMapper.Mapper.Map(_productRepository.AddProduct(productData), productdto);
            return productdto;
        }

        public bool DeleteProduct(int productId)
        {
            return _productRepository.DeleteProduct(productId);
        }


        public ProductDto EditProduct(ProductDto product)
        {
            ProductDto productdto = new ProductDto();
            Product.Repository.Product productData = new Product.Repository.Product();
            AutoMapper.Mapper.Map(product, productData);
            AutoMapper.Mapper.Map(_productRepository.EditProduct(productData), productdto);
            return productdto;
        }

        public List<ProductDto> GetAllProduct()
        {
            List<ProductDto> productDto = new List<ProductDto>() ;
            AutoMapper.Mapper.Map(_productRepository.GetAllProduct(), productDto);
            return productDto;
        }


        public ProductDto GetProductById(int productId)
        {
            ProductDto productDto = new ProductDto();
            AutoMapper.Mapper.Map(_productRepository.GetProductById(productId), productDto);
            return productDto;
        }

        public ProductDto GetProductByNumber(string productNumber)
        {
            ProductDto productDto = new ProductDto();
            AutoMapper.Mapper.Map(_productRepository.GetProductByNumber(productNumber), productDto);
            return productDto;
        }


    }
}
