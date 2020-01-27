using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SecurityLab1_Starter.Models;

namespace SecurityLab1_Starter.Controllers
{
    [Authorize]
    public class InventoryController : Controller
    {
        public ActionResult Index()
        {
            //throw new Exception();
            return View();
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            //Log the error!!
            using (System.IO.StreamWriter w = System.IO.File.AppendText("C:/Users/Kristian/Desktop/log.txt"))
                Logger.Log(filterContext.Exception.Message,w);
            //Redirect or return a view, but not both.
            filterContext.Result = RedirectToAction("Index", "Error");
        }
    }
}