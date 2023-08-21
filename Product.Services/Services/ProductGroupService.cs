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
    public class ProductGroupService : IProductGroupServices
    {
        private IProductGroupRepository _productGroupRepository;
        public ProductGroupService()
        {
            _productGroupRepository = new ProductGroupRepository();
        }

        public ProductGroupDto AddProductGroup(ProductGroupDto productGroup)
        {
            ProductGroupDto productGroupdto = new ProductGroupDto();
            ProductGroup productGroupData = new ProductGroup();
            AutoMapper.Mapper.Map(productGroup, productGroupData);
            AutoMapper.Mapper.Map(_productGroupRepository.AddProductGroup(productGroupData), productGroupdto);
            return productGroupdto;
        }

        public bool DeleteProductGroup(int productGroupId)
        {
            return _productGroupRepository.DeleteProductGroup(productGroupId);
        }


        public ProductGroupDto EditProductGroup(ProductGroupDto productGroup)
        {
            ProductGroupDto productGroupdto = new ProductGroupDto();
            ProductGroup productGroupData = new ProductGroup();
            AutoMapper.Mapper.Map(productGroup, productGroupData);
            AutoMapper.Mapper.Map(_productGroupRepository.EditProductGroup(productGroupData), productGroupdto);
            return productGroupdto;
        }

        public List<ProductGroupDto> GetAllProductGroup()
        {
            List<ProductGroupDto> productGroupDto = new List<ProductGroupDto>() ;
            AutoMapper.Mapper.Map(_productGroupRepository.GetAllProductGroup(), productGroupDto);
            return productGroupDto;
        }


        public ProductGroupDto GetProductGroupById(int productGroupId)
        {
            ProductGroupDto productGroupDto = new ProductGroupDto();
            AutoMapper.Mapper.Map(_productGroupRepository.GetProductGroupById(productGroupId), productGroupDto);
            return productGroupDto;
        }

        public ProductGroupDto GetProductGroupByCode(string productGroupCode)
        {
            ProductGroupDto productGroupDto = new ProductGroupDto();
            AutoMapper.Mapper.Map(_productGroupRepository.GetProductGroupByCode(productGroupCode), productGroupDto);
            return productGroupDto;
        }

    }
}
