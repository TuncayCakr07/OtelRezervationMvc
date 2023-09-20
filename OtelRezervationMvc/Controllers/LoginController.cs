using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using OtelRezervationMvc.Models;

namespace OtelRezervationMvc.Controllers
{
    public class LoginController : Controller
    {
        DbOtelEntities db=new DbOtelEntities();
        // GET: Login

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(TblYeniKayit t)
        {
            var data = db.TblYeniKayit.FirstOrDefault(x => x.Mail == t.Mail && x.Sifre == t.Sifre);
            if (data != null)
            {
                FormsAuthentication.SetAuthCookie(data.Mail, false);
                Session["Mail"]=data.Mail.ToString();

                return RedirectToAction("Index","Misafir");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}