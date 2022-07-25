using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kargo_Takip_Projesi.Models.Veri_Tabani;

namespace Kargo_Takip_Projesi.Controllers
{
    [Authorize]
    public class AliciController : Controller
    {
       
        // GET: Alici
        Kargo_TakipEntities db = new Kargo_TakipEntities();
        public ActionResult Index()
        {
            var degerler = db.Alici_Bilgileri.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniAlici()
        {
            return View();
        }


        [HttpPost]
        public ActionResult YeniAlici(Alici_Bilgileri a1)
        {
            db.Alici_Bilgileri.Add(a1);
            db.SaveChanges();
            return View();
        }

        public ActionResult AliciGuncelle(int id)
        {
            var a1 = db.Alici_Bilgileri.Find(id);
            return View("AliciGuncelle", a1);
        }
        public ActionResult Guncelle(Alici_Bilgileri a1)
        {
            var gnclla1 = db.Alici_Bilgileri.Find(a1.Alici_Id);
            gnclla1.Alici_Ad = a1.Alici_Ad;
            gnclla1.Alici_Soyad = a1.Alici_Soyad;
            gnclla1.Alici_Adres = a1.Alici_Adres;
            gnclla1.Alici_Ilce = a1.Alici_Ilce;
            gnclla1.Alici_Il = a1.Alici_Il;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}