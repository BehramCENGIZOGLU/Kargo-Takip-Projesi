using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kargo_Takip_Projesi.Models.Veri_Tabani;

namespace Kargo_Takip_Projesi.Controllers
{
    [Authorize]
    public class GondericiController : Controller
    {
        // GET: Gonderici
        Kargo_TakipEntities db = new Kargo_TakipEntities();
        public ActionResult Index()
        {
            var degerler = db.Gönderici_Bilgileri.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniGonderici()
        {
            return View();
        }


        [HttpPost]
        public ActionResult YeniGonderici(Gönderici_Bilgileri g1)
        {
            db.Gönderici_Bilgileri.Add(g1);
            db.SaveChanges();
            return View();
        }
        public ActionResult GondericiGuncelle(int id)
        {
            var g1 = db.Gönderici_Bilgileri.Find(id);
            return View("GondericiGuncelle", g1);
        }
        public ActionResult Guncelle(Gönderici_Bilgileri g1)
        {
            var gncllg1 = db.Gönderici_Bilgileri.Find(g1.Gonderici_Id);
            gncllg1.Gonderici_Ad = g1.Gonderici_Ad;
            gncllg1.Gonderici_Soyad = g1.Gonderici_Soyad;
            gncllg1.Gonderici_Adres = g1.Gonderici_Adres;
            gncllg1.Gonderici_Ilce = g1.Gonderici_Ilce;
            gncllg1.Gonderici_Il = g1.Gonderici_Il;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}