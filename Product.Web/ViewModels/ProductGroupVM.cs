using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Web.ViewModels
{
    public class ProductGroupVM
    {
 
        public ProductGroupVM()
        {
            this.Agreements = new HashSet<AgreementVM>();
            this.Products = new HashSet<ProductVM>();
        }

        public int Id { get; set; }
        public string GroupDescription { get; set; }
        public string GroupCode { get; set; }
        public bool Active { get; set; }
        public ICollection<AgreementVM> Agreements { get; set; }
        public ICollection<ProductVM> Products { get; set; }
    }
}
