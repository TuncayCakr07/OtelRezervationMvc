using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using OtelRezervationMvc.Models;

namespace OtelRezervationMvc.Controllers
{
    [Authorize]
    public class MisafirController : Controller
    {
        DbOtelEntities db = new DbOtelEntities();
        // GET: Misafir
        public ActionResult Index()
        {
            var loginmail = (string)Session["Mail"];
            var guestinfo=db.TblYeniKayit.Where(x=> x.Mail==loginmail).FirstOrDefault();
            return View(guestinfo);
        }

        public ActionResult Rezervasyonlarim() 
        {
            var loginmail = (string)Session["Mail"];
            //ViewBag.loginmail = loginmail;
            var guestid=db.TblYeniKayit.Where(x=>x .Mail==loginmail).Select(y => y.ID).FirstOrDefault();
            var data = db.TblRezervasyon.Where(x => x.Misafir == guestid).ToList();
            return View(data);
        }

        public ActionResult MisafirBilgileriGuncelle(TblYeniKayit t)
        {
            var guest = db.TblYeniKayit.Find(t.ID);
            guest.AdSoyad = t.AdSoyad;
            guest.Sifre = t.Sifre;
            guest.Telefon=t.Telefon;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index","AnaSayfa");
        }

        public ActionResult GelenMesajlar()
        {
            var loginmail = (string)Session["Mail"];
            var mesajlar=db.TblMesajGuest.Where(x=> x.Alici==loginmail).ToList();
            return View(mesajlar);
        }

        public ActionResult GidenMesajlar()
        {
            var loginmail = (string)Session["Mail"];
            var mesajlar = db.TblMesajGuest.Where(x => x.Gonderen == loginmail).ToList();
            return View(mesajlar);
        }

        public ActionResult MesajDetay(int id)
        {
            var mesaj=db.TblMesajGuest.Where(x=> x.MesajID==id).FirstOrDefault();
            return View(mesaj);
        }

        [HttpGet]
        public ActionResult YeniMesaj()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniMesaj(TblMesajGuest t)
        {
            var guestmail = (string)Session["Mail"];
            t.Gonderen= guestmail;
            t.Alici = "Admin";
            t.Tarih =DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TblMesajGuest.Add(t);
            db.SaveChanges();
            return RedirectToAction("GidenMesajlar");
        }
    }
}