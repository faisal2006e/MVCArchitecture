﻿using Product.Web.AppFilters;
using System.Web;
using System.Web.Mvc;

namespace Product.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new GlobalExceptionHandlerAttribute());
        }
    }
}
