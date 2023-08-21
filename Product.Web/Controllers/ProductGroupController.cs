using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Product.Web.Models;
using System.Data.Entity;
using Product.Models.Dtos;
using Product.Services.IServices;
using Product.Services.Services;
using Product.Web.ViewModels;
using Product.Repository;
using Product.Core;

namespace Product.Web.Controllers
{
    public class ProductGroupController : Controller
    {
        private IProductGroupServices _productGroupServices;

        public ProductGroupController()
        {
            this._productGroupServices = new ProductGroupService();
        }

        //
        // GET: /ProductGroup/
        public ActionResult Index()
        {
            if (!Request.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            return View();
        }

        public ActionResult GetData()
        {
            try
            {
                List<ProductGroupVM> productGroupVM = new List<ProductGroupVM>();
                var employeData = _productGroupServices.GetAllProductGroup();
                return Json(new { data = employeData }, JsonRequestBehavior.AllowGet); 
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }


        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            try
            {
                ProductGroupVM productGroupVM = new ProductGroupVM();
                ProductGroupDto productGroupDto = new ProductGroupDto();
                if (id == 0)
                    return View("AddOrEdit", productGroupVM);
                else
                {
                    productGroupDto = _productGroupServices.GetProductGroupById(id);
                    AutoMapper.Mapper.Map(productGroupDto, productGroupVM);
                    return View("AddOrEdit", productGroupVM);

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        [HttpPost]
        public ActionResult Save(ProductGroupDto emp)
        {
            try
            {
                ProductGroupDto productGroupDto = new ProductGroupDto();
                ProductGroupVM productGroupVM = new ProductGroupVM();

                productGroupDto = _productGroupServices.GetProductGroupByCode(emp.GroupCode);
                if (emp.Id == 0)
                {
                    if (productGroupDto != null && productGroupDto.Active == true)
                    {
                        return Json(new { success = false, message = "Record is exists with same Group Code." }, JsonRequestBehavior.AllowGet);
                    }

                    _productGroupServices.AddProductGroup(emp);
                    return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    if (productGroupDto != null && productGroupDto.Id != emp.Id && productGroupDto.Active == true)
                    {
                        return Json(new { success = false, message = "Record is exists with same Group Code." }, JsonRequestBehavior.AllowGet);
                    }

                    _productGroupServices.EditProductGroup(emp);
                    return Json(new { success = true, message = "Updated Successfully" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            

        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                _productGroupServices.DeleteProductGroup(id);
                return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
    }
}