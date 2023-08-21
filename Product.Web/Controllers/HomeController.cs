using Microsoft.AspNet.Identity;
using Product.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Product.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            try
            {
                
                if (Request.IsAuthenticated)
                {
                    GlobalDeclarations.UserID = User.Identity.GetUserId();
                    return RedirectToAction("Index", "Agreement");
                }
                else
                {
                    return RedirectToAction("Login", "Account");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            
        }
    }
}