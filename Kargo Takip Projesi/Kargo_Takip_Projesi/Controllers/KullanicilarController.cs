using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kargo_Takip_Projesi.Models.Veri_Tabani;
using System.Web.Security;
using System.Net.Mail;
using System.Net;

namespace Kargo_Takip_Projesi.Controllers
{
    [AllowAnonymous]
    
    public class KullanicilarController : Controller
    {
        Kargo_TakipEntities db = new Kargo_TakipEntities();
        // GET: Kullanicilar
        [HttpGet]
   
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Login(Yonetici_Kayit y)
        {
            var kullanici = db.Yonetici_Kayit.FirstOrDefault(x => x.Yonetici_Kullanici_Adi == y.Yonetici_Kullanici_Adi && x.Yonetici_Sifre == y.Yonetici_Sifre);
            if(kullanici!=null)
            {
                FormsAuthentication.SetAuthCookie(y.Yonetici_Kullanici_Adi,false);
                return RedirectToAction("Index","Gonderici");
            }
            ViewBag.hata = "Kullanıcı Adı Veya Şifre Yanlış";
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        [HttpGet]
        public ActionResult Sifremi_Unuttum()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Sifremi_Unuttum(Yonetici_Kayit y)
        {
            var model = db.Yonetici_Kayit.Where(x => x.Yonetici_Email == y.Yonetici_Email).FirstOrDefault();
            if(model!=null)
            {
                Guid rastgele = Guid.NewGuid();
                model.Yonetici_Sifre = rastgele.ToString().Substring(0,6);
                db.SaveChanges();
                
                return RedirectToAction("Login");
            }
            ViewBag.hata = "Böyle Bir E-mail Adresi Bulunamadı.";
            return View();
        }


       

        

    }

}