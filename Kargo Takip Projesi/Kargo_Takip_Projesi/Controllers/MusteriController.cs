using Kargo_Takip_Projesi.Models.Veri_Tabani;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kargo_Takip_Projesi.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        Kargo_TakipEntities db = new Kargo_TakipEntities();

        public class kargo_duzenleme
        {
            public List<Alici_Bilgileri> alici { get; set; }
            public List<Gönderici_Bilgileri> gonder { get; set; }
            public List<Kargo_Durum> kargo { get; set; }
            public kargo_duzenleme()
            {
                this.kargo = new List<Kargo_Durum>();
                this.alici = new List<Alici_Bilgileri>();
                this.gonder = new List<Gönderici_Bilgileri>();
            }
        }

        public ActionResult Musteri_urun()
        {
            kargo_duzenleme krg = new kargo_duzenleme();
            krg.alici = db.Alici_Bilgileri.ToList();
            krg.gonder = db.Gönderici_Bilgileri.ToList();
            krg.kargo = db.Kargo_Durum.ToList();
            return View(krg);
        }
        [HttpGet]
        public ActionResult BarkodNumarasi()
        {
            return View();
        }
        

          
    }
}