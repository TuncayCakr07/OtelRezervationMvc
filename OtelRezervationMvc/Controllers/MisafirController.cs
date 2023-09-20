using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OtelRezervationMvc.Models;

namespace OtelRezervationMvc.Controllers
{
    public class MisafirController : Controller
    {
        DbOtelEntities db = new DbOtelEntities();
        // GET: Misafir
        public ActionResult Index()
        {
            var loginmail = (string)Session["Mail"];
            var guestinfo=db.TblYeniKayit.Where(x=> x.Mail==loginmail).ToList();
            return View(guestinfo);
        }

        public ActionResult Rezervasyonlarim() 
        {
            var loginmail = (string)Session["Mail"];
            ViewBag.loginmail = loginmail;
            var data = db.TblRezervasyon.Where(x => x.Misafir == 1).ToList();
            return View(data);
        }
    }
}