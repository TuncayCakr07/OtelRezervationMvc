using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using OtelRezervationMvc.Models;

namespace OtelRezervationMvc.Controllers
{
    public class IletisimController : Controller
    {
        // GET: iletisim
        DbOtelEntities db = new DbOtelEntities();
        public ActionResult Index()
        {
            var data = db.Tbliletisim.ToList();
            return View(data);
        }

        [HttpGet]
        public PartialViewResult MesajGonder()
        {
            return PartialView();
        }

        [HttpPost]
       public PartialViewResult MesajGonder(TblMesaj t)
        {
            db.TblMesaj.Add(t);
            db.SaveChanges();
            return PartialView("MesajGonder");
        }
    }
}