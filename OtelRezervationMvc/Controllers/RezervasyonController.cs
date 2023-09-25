using OtelRezervationMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OtelRezervationMvc.Controllers
{
    public class RezervasyonController : Controller
    {
        // GET: Rezervasyon
        DbOtelEntities db=new DbOtelEntities();

        [Authorize]
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(TblRezervasyon t)
        {
            var loginmail = (string)Session["Mail"];
            var guestid = db.TblYeniKayit.Where(x => x.Mail == loginmail).Select(x=> x.ID).FirstOrDefault();

            t.Durum=11;
            t.Misafir=guestid;
            db.TblRezervasyon.Add(t);
            db.SaveChanges();
            return RedirectToAction("Rezervasyonlarim","Misafir");
        }
    }
}