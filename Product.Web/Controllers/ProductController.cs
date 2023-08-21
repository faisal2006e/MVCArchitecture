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
    public class ProductController : Controller
    {
        private IProductServices _productServices;
        private IProductGroupServices _productGroupServices;

        public ProductController()
        {
            this._productServices = new ProductService();
            this._productGroupServices = new ProductGroupService();
        }

        //
        // GET: /Product/
        public ActionResult Index()
        {
            try
            {
                if (!Request.IsAuthenticated)
                {
                    return RedirectToAction("Login", "Account");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
            
            return View();
        }

        public ActionResult GetData()
        {
            try
            {
                List<ProductVM> productVM = new List<ProductVM>();
                var employeData = _productServices.GetAllProduct();
                List<ProductGroupDto> productGroupDto = new List<ProductGroupDto>();
                List<SelectListItem> groupList = new List<SelectListItem>();

                productGroupDto = _productGroupServices.GetAllProductGroup();

                foreach (ProductGroupDto item in productGroupDto)
                {
                    groupList.Add(
                        new SelectListItem
                        {
                            Text = item.GroupDescription,
                            Value = item.Id.ToString(),
                        });
                }

                ViewBag.ProductGroups = groupList;
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
                ProductVM productVM = new ProductVM();
                ProductDto productDto = new ProductDto();
                List<ProductGroupDto> productGroupDto = new List<ProductGroupDto>();
                List<SelectListItem> groupList = new List<SelectListItem>();


                if (id != 0)
                {
                    productDto = _productServices.GetProductById(id);
                    AutoMapper.Mapper.Map(productDto, productVM);
                }


                productGroupDto = _productGroupServices.GetAllProductGroup();

                foreach (ProductGroupDto item in productGroupDto)
                {
                    groupList.Add(
                        new SelectListItem
                        {
                            Text = item.GroupDescription,
                            Value = item.Id.ToString(),
                        });
                }

                ViewBag.ProductGroups = groupList;


                return View(productVM);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        [HttpPost]
        public ActionResult Save(ProductDto emp)
        {
            try
            {
                ProductDto productDto = _productServices.GetProductByNumber(emp.ProductNumber);
                ProductVM productVM = new ProductVM();

                if (emp.Id == 0)
                {
                    if (productDto != null && productDto.Active == true)
                    {
                        return Json(new { success = false, message = "Record is exists with same Product Number." }, JsonRequestBehavior.AllowGet);
                    }
                    _productServices.AddProduct(emp);
                    return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    if (productDto != null && productDto.Id != emp.Id && productDto.Active == true)
                    {
                        return Json(new { success = false, message = "Record is exists with same Product Number." }, JsonRequestBehavior.AllowGet);
                    }

                    _productServices.EditProduct(emp);
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
                _productServices.DeleteProduct(id);
                return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
    }
}