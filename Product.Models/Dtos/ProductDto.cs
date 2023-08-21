using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Models.Dtos
{
    public class ProductDto
    {
        public ProductDto()
        {
            
        }

        public int Id { get; set; }
        public int ProductGroupId { get; set; }
        public string ProductDescription { get; set; }
        public string ProductNumber { get; set; }
        public decimal Price { get; set; }
        public bool Active { get; set; }

        public ProductGroupDto ProductGroup { get; set; }
    }
}
