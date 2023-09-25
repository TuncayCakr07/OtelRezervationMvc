using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OtelRezervationMvc;
using OtelRezervationMvc.Models;

namespace OtelRezervationMvc.Controllers
{
    public class DefaultController : Controller
    {
        DbOtelEntities db=new DbOtelEntities();
        // GET: Default
        public ActionResult AnaSayfa()
        {
            return View();
        }
        public ActionResult Hakkimizda() 
        {
            return View();
        }

        public PartialViewResult İstatistik()
        {
            return PartialView();
        }

        public ActionResult PartialFooter()
        {
            var doluoda=db.TblOda.Where(x=> x.Durum!=1).Count();
            ViewBag.d=doluoda;
            var bosoda = db.TblOda.Where(x => x.Durum == 1).Count();
            ViewBag.b = bosoda;
            return PartialView();
        }

    }
}