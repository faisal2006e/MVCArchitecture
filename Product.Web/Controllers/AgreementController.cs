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
using Microsoft.AspNet.Identity;

namespace Product.Web.Controllers
{
    public class AgreementController : Controller
    {
        private IAgreementServices _agreementServices;
        private IProductServices _productServices;
        private IProductGroupServices _productGroupServices;
        public AgreementController()
        {
            this._agreementServices = new AgreementService();
            this._productServices = new ProductService();
            this._productGroupServices = new ProductGroupService();
        }

        //
        // GET: /Agreement/
        public ActionResult Index()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }

        public ActionResult GetData()
        {
            try
            {
                List<AgreementVM> agreementVM = new List<AgreementVM>();
                var employeData = _agreementServices.GetAllAgreement();
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
                AgreementVM agreementVM = new AgreementVM();
                AgreementDto agreementDto = new AgreementDto();
                List<ProductGroupDto> productGroupDto = new List<ProductGroupDto>();
                List<SelectListItem> groupList = new List<SelectListItem>();
                List<ProductDto> productDto = new List<ProductDto>();
                List<SelectListItem> productList = new List<SelectListItem>();

                if (id != 0)
                {
                    agreementDto = _agreementServices.GetAgreementById(id);
                    AutoMapper.Mapper.Map(agreementDto, agreementVM);
                }

                productDto = _productServices.GetAllProduct();
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

                foreach (ProductDto item in productDto)
                {
                    productList.Add(
                        new SelectListItem
                        {
                            Text = item.ProductDescription,
                            Value = item.Id.ToString(),
                        });
                }

                ViewBag.ProductGroups = groupList;
                ViewBag.Products = productList;

                return View(agreementVM);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpPost]
        public ActionResult Save(AgreementDto emp)
        {
            try
            {
                emp.UserId = User.Identity.GetUserId();

                AgreementVM agreementVM = new AgreementVM();
                if (emp.Id == 0)
                {
                    _agreementServices.AddAgreement(emp);
                    return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    _agreementServices.EditAgreement(emp);
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
                _agreementServices.DeleteAgreement(id);
                return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            
        }
    }
}