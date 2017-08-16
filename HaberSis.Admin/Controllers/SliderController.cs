using HaberSis.Admin.Class;
using HaberSis.Admin.CustomFilter;
using HaberSis.Core.Infrastructure;
using HaberSis.Data.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HaberSis.Admin.Helper;
using System.IO;

namespace HaberSis.Admin.Controllers
{
    public class SliderController : Controller
    {

        #region Ctor
        private readonly ISliderRepository _sliderRepository;

        public SliderController(ISliderRepository sliderRepository)
        {
            _sliderRepository = sliderRepository;
        }
        #endregion
        // GET: Slider

        #region Listeleme
        [LoginFilter]
        [HttpGet]
        public ActionResult Index(int sayfa=1)
        {
            //var slider = _sliderRepository.GetAll().ToPagedList(sayfa,10);
            return View(_sliderRepository.GetAll().OrderByDescending(x => x.ID).ToPagedList(sayfa, 10));
        }


        #endregion

        #region Ekle
        [HttpGet]
        [LoginFilter]
        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        [LoginFilter]
        public JsonResult Ekle(Slider slider, HttpPostedFileBase ResimUrl)
        {
            if (slider.ResimUrl != null)
            {
                if (ResimUrl.ContentLength > 0)
                {
                    string Dosya = Guid.NewGuid().ToString().Replace("-", "");
                    string Uzanti = System.IO.Path.GetExtension(Request.Files[0].FileName);
                    string ResimYolu = "/External/Slider/" + Dosya + Uzanti;

                    ResimUrl.SaveAs(Server.MapPath(ResimYolu));
                    slider.ResimUrl = ResimYolu;
                }
                _sliderRepository.Insert(slider);
                try
                {
                    _sliderRepository.Save();
                    return Json(new ResultJson { Success = true, Message = "Slider Ekleme İşleminiz başarılı!" });
                }
                catch (Exception)
                {

                    return Json(new ResultJson { Success = false, Message = "Slider Ekleme İşleminiz başarısız!" });
                }
            }

            return Json(new ResultJson { Success = false, Message = "Slider Ekleme İşleminiz başarısız!" });

        }
        #endregion

        #region Düzenle
        [HttpGet]
        [LoginFilter]
        public ActionResult Duzenle(int ID)
        {
            var Slider = _sliderRepository.GetById(ID);
            if (Slider!=null)
            {
                return View(Slider);
            }
            return View();
        }

        [HttpPost]
        public ActionResult Duzenle(Slider slider,HttpPostedFileBase ResimUrl)
        {
            if (ModelState.IsValid)
            {
                var dbslider = _sliderRepository.GetById(slider.ID);
                dbslider.Baslik = slider.Baslik;
                dbslider.Aciklama = slider.Aciklama;
                dbslider.AktifMi = slider.AktifMi;
                dbslider.Url = slider.Url;
                var res = dbslider.ResimUrl;

                //string dosyaYolu = Server.MapPath(res);
                //FileInfo file = new FileInfo(dosyaYolu);
                //if (file.Exists)
                //{
                //    file.Delete();
                //}
                if (ResimUrl!=null &&ResimUrl.ContentLength>0)
                {
                    if (dbslider.ResimUrl!=null)
                    {
                        string url = dbslider.ResimUrl;
                        string pat = Server.MapPath(url);
                        FileInfo file = new FileInfo(pat);
                        if (file.Exists)
                        {
                            file.Delete();
                        }
                       

                    }
                    ResimYukle<Slider>.Resim(ResimUrl,slider);
                  
                    dbslider.ResimUrl = slider.ResimUrl;
                }
                try
                {
                    _sliderRepository.Save();
                    return Json(new ResultJson { Success = true, Message = "SLİDER DZENLENDİ" });
                }
                catch (Exception ex)
                {

                    //Logyaz

                    return Json(new ResultJson {Success=false,Message="slider ekleme başarısız" });
                }
            }
     
            return Json(new ResultJson { Success = false, Message = "bilinmeyen hata oluştu" });

        }

        #endregion


        #region Sil

        public JsonResult Sil(Slider slider)
        {
            var dbslider = _sliderRepository.GetById(slider.ID);
            try
            {
                if (dbslider.ResimUrl != null)
                {
                    var resim = dbslider.ResimUrl;
                    var yol = Server.MapPath(resim);
                    FileInfo file = new FileInfo(yol);
                    if (file.Exists)
                    {
                        file.Delete();
                    }
                    _sliderRepository.Delete(dbslider.ID);
                    _sliderRepository.Save();
                    return Json(new ResultJson { Success = true, Message = "Slider silindi" });
                }
            }
            catch (Exception)
            {

                return Json(new ResultJson { Success = false, Message = "Slider silinemedi" });
            }

            return Json(new ResultJson { Success = false, Message = "Bilinmeyen hata!" });



        }

        #endregion

    }
}