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
    public class ProductGroupRepository : IProductGroupRepository
    {
        private ProductDBEntities _db;
        public ProductGroupRepository()
        {
            _db = new ProductDBEntities();
        }

        public ProductGroup AddProductGroup(ProductGroup productGroup)
        {
            _db.ProductGroups.Add(productGroup);
            _db.SaveChanges();

            return productGroup;

        }

        public bool DeleteProductGroup(int productGroupId)
        {
            var getProductGroup = _db.ProductGroups.Where(x => x.Id == productGroupId).FirstOrDefault<ProductGroup>();
            if (getProductGroup != null)
            {
                _db.ProductGroups.Remove(getProductGroup);
                _db.SaveChanges();
                return true;
            }
            return false;
        }

        public ProductGroup EditProductGroup(ProductGroup productGroup)
        {
            var oldProductGroup = _db.ProductGroups.FirstOrDefault(e => e.Id == productGroup.Id);

            oldProductGroup.GroupDescription = productGroup.GroupDescription;
            oldProductGroup.GroupCode = productGroup.GroupCode;
            oldProductGroup.Active = productGroup.Active;
            
            _db.SaveChanges();

            return productGroup;
        }

        public List<ProductGroup> GetAllProductGroup()
        {
            //using (var dbContext = new DBModel(CommonDeclarations.DBContextConnectionString))
            //{
            //    return dbContext.ProductGroups.ToList();
            //}
            return _db.ProductGroups.ToList<ProductGroup>();
        }

        public ProductGroup GetProductGroupById(int productGroupId)
        {
            return _db.ProductGroups.Where(x => x.Id == productGroupId).FirstOrDefault<ProductGroup>();
        }

        public ProductGroup GetProductGroupByCode(string productGroupCode)
        {
            return _db.ProductGroups.Where(x => x.GroupCode == productGroupCode).FirstOrDefault<ProductGroup>();
        }
    }
}
