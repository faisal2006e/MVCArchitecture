using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Models.Dtos
{
    public class ProductGroupDto
    {
 
        public ProductGroupDto()
        {
        }

        public int Id { get; set; }
        public string GroupDescription { get; set; }
        public string GroupCode { get; set; }
        public bool Active { get; set; }
       
    }
}
