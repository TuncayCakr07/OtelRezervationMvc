using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OtelRezervationMvc.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult AnaSayfa()
        {
            return View();
        }
        public ActionResult Hakkimizda() 
        {
            return View();
        }
        public ActionResult PartialFooter()
        {
            return PartialView();
        }
    }
}