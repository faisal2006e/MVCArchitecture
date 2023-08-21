using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Product.Web.ViewModels
{
    public class ProductVM
    {
        public ProductVM()
        {
            //this.ProductGroupList = new List<SelectListItem>();
        }

        public int Id { get; set; }
        public int ProductGroupId { get; set; }
        public string ProductDescription { get; set; }
        public string ProductNumber { get; set; }
        public decimal Price { get; set; }
        public bool Active { get; set; }
        //public List<SelectListItem> ProductGroupList { get; set; }
    }
}
