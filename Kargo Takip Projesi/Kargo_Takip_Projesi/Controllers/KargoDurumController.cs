using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kargo_Takip_Projesi.Models.Veri_Tabani;

namespace Kargo_Takip_Projesi.Controllers
{
    
    public class KargoDurumController : Controller
    {
        // GET: KargoDurum
        Kargo_TakipEntities db = new Kargo_TakipEntities();
        public ActionResult Index1()
        {
            var degerler = db.Kargo_Durum.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniKargo()
        {
            List<SelectListItem> degerler = (from i in db.Urun_Bilgileri.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.Urun_Adi,
                                                 Value = i.Urun_Barkod_Numarasi.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;



            return View();
        }


        [HttpPost]
        public ActionResult YeniKargo(Kargo_Durum kd1)
        {
            var urn = db.Urun_Bilgileri.Where(m => m.Urun_Barkod_Numarasi == kd1.Urun_Bilgileri.Urun_Barkod_Numarasi).FirstOrDefault();
            kd1.Urun_Bilgileri = urn;
            db.Kargo_Durum.Add(kd1);
            db.SaveChanges();
            return RedirectToAction("Index1");
        }
        public ActionResult KargoGuncelle(int id)
        {
            var gnc1 = db.Kargo_Durum.Find(id);
            return View("KargoGuncelle", gnc1);
        }
        public ActionResult Guncelle(Kargo_Durum kd2)
        {
            var kgnc1 = db.Kargo_Durum.Find(kd2.Kargo_Id);
            kgnc1.Kargo_Islem_Tarihi = kd2.Kargo_Islem_Tarihi;
            kgnc1.Kargo_Durumu = kd2.Kargo_Durumu;

            db.SaveChanges();
            return RedirectToAction("Index1");
        }
    }
}