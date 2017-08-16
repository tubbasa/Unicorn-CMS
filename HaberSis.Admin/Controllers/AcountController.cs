using HaberSis.Core.Infrastructure;
using HaberSis.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HaberSis.Admin.Controllers
{
    public class AcountController : Controller
    {
        #region Kullanıcı
        private readonly IKullaniciRepository _kullaniciRepository;
      
        public AcountController(IKullaniciRepository kullaniciRepository)
        {
            _kullaniciRepository = kullaniciRepository;
          
        }

        #endregion

        // GET: Acount

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Kullanici kullanici)
        {
            var KullaniciVarMi = _kullaniciRepository.GetMany(x => x.Email==kullanici.Email && x.Sifre==kullanici.Sifre &&
            x.AktifMi).SingleOrDefault();
            if (KullaniciVarMi!=null)
            {
                if (KullaniciVarMi.Rol.RolAdi=="Admin")
                {
                    Session["KullaniciEmail"]=KullaniciVarMi.Email;
                    Session["KullaniciId"] = KullaniciVarMi.ID;
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    ViewBag.Mesaj = "Yetkisiz Kullanıcı!";
                    return View();
                }
            }
            ViewBag.Mesaj = "Kullanıcı Bulunamadı";
            return View();
        }
    }
}