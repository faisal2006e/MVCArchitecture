using Product.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Services.IServices
{
    public interface IProductGroupServices
    {
        ProductGroupDto AddProductGroup(ProductGroupDto productGroup);
        bool DeleteProductGroup(int productGroupId);
        ProductGroupDto EditProductGroup(ProductGroupDto productGroup);
        List<ProductGroupDto> GetAllProductGroup();
        ProductGroupDto GetProductGroupById(int productGroupId);
        ProductGroupDto GetProductGroupByCode(string productGroupCode);
    }
    
}
