using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OtelRezervationMvc.Models;
namespace OtelRezervationMvc.Controllers
{
    public class KayitController : Controller
    {
        // GET: Kayit
        DbOtelEntities db=new DbOtelEntities();


        [HttpGet]
        public ActionResult KayitOl()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KayitOl(TblYeniKayit t)
        {
            db.TblYeniKayit.Add(t);
            db.SaveChanges();
            return RedirectToAction("Index","Login");
        }
    }
}