﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZAP.Model;

namespace WebSite.Controllers
{
    public class ErrorController : Controller
    {
        //
        // GET: /Error/

        public ActionResult Index()
        {
            var errorData = Session["errorData"] as OperationResult<BaseModel>; 
            return View("Error",  errorData );
        }

    }
}
