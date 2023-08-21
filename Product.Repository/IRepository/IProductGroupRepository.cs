using Product.Models.Dtos;
using Product.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Repository.IRepository
{
    public interface IProductGroupRepository
    {
        ProductGroup AddProductGroup(ProductGroup productGroup);
        bool DeleteProductGroup(int productGroupId);
        ProductGroup EditProductGroup(ProductGroup productGroup);
        List<ProductGroup> GetAllProductGroup();
        ProductGroup GetProductGroupById(int productGroupId);
        ProductGroup GetProductGroupByCode(string productGroupCode);
    }
}
