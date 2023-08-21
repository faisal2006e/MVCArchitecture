
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Product.Web.AppFilters
{
    using Product.Core;
    using System.Web.Mvc;

    public class GlobalExceptionHandlerAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            // Log the exception or perform any other necessary actions

            ErrorLogger.WriteToErrorLog(filterContext.Exception.Message, filterContext.Exception.StackTrace);


            // Optionally, you can set the view name and model for the error view
            filterContext.ExceptionHandled = true;
            filterContext.Result = new ViewResult
            {
                ViewName = "Error", // Specify the name of your error view
                ViewData = new ViewDataDictionary
                {
                    // Pass the exception details to the view
                    ["Exception"] = filterContext.Exception
                }
            };
        }
    }

}