using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kargo_Takip_Projesi.Models.Veri_Tabani;

namespace Kargo_Takip_Projesi.Controllers
{
    [Authorize]
    public class UrunController : Controller
    {
        // GET: Urun
        Kargo_TakipEntities db = new Kargo_TakipEntities();
        public ActionResult Index()
        {
            var degerler = db.Urun_Bilgileri.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniUrun()
        {
            return View();
        }


        [HttpPost]
        public ActionResult YeniUrun(Urun_Bilgileri u1)
        {
            db.Urun_Bilgileri.Add(u1);
            db.SaveChanges();
            return View();
        }

        public ActionResult UrunGuncelle(int id)
        {
            var u1 = db.Urun_Bilgileri.Find(id);
            return View("UrunGuncelle", u1);
        }
        public ActionResult Guncelle(Urun_Bilgileri u1)
        {
            var gncllu1 = db.Urun_Bilgileri.Find(u1.Urun_Barkod_Numarasi);
            gncllu1.Urun_Adi = u1.Urun_Adi;
            gncllu1.Urun_Aciklama = u1.Urun_Aciklama;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}