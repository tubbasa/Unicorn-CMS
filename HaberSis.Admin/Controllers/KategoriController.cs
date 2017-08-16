using HaberSis.Admin.Class;
using HaberSis.Admin.CustomFilter;
using HaberSis.Core.Infrastructure;
using HaberSis.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace HaberSis.Admin.Controllers
{
    public class KategoriController : Controller
    {

        #region Kategori
        private readonly IKategoriRepository _kategoriRepository;

        public KategoriController(IKategoriRepository kategorirepository)
        {
            _kategoriRepository = kategorirepository;
        
        }
        #endregion
        // GET: Kategori

        #region KategoriListele
        [LoginFilter]
        [HttpGet]
        public ActionResult Index(int Sayfa=1)
        {
            return View(_kategoriRepository.GetAll().OrderByDescending(x=>x.ID).ToPagedList(Sayfa,10));
        }

        #endregion

        #region KategoriEkle
        [HttpGet]
        public ActionResult Ekle()
        {

            SetKategoriListele();
            return View();
        }
        [LoginFilter]
        [HttpPost]
        public JsonResult Ekle(Kategori kategori)
        {
            try
            {
             
                _kategoriRepository.Insert(kategori);
                _kategoriRepository.Save();
                return Json(new ResultJson {Success=true,Message="Kategori ekleme işleminiz başarılı" });
            }
            catch (Exception e)
            {
                //Loglama yaptırabiliriz
                return Json(new ResultJson { Success=false,Message="Hata oluştu"});
            }
        
        }

        #endregion

        #region KategoriDüzenle

        [HttpGet]
        public ActionResult Duzenle(int Id)
        {
            var kat = _kategoriRepository.GetById(Id);
            if (kat==null)
            {
                throw new Exception("Kategori bulunamadı");
            }
            SetKategoriListele();
            WorkFlow();
            return View(kat);
        }

        [HttpPost]
        public JsonResult Duzenle(Kategori kategori)
        {
          
                Kategori dbkat = _kategoriRepository.GetById(kategori.ID);
                dbkat.AktifMi = kategori.AktifMi;
                dbkat.KategoriAdi = kategori.KategoriAdi;
                dbkat.ParentID = kategori.ParentID;
                dbkat.Url = kategori.Url;
                _kategoriRepository.Save();
                return Json(new ResultJson { Success=true,Message="Düzenleme işlemi başarılı"});
            
            //return Json(new ResultJson { Success=false,Message="Düzenleme sırasında bir sorun oluştu"});
        
        }
        #endregion

        #region Sil
        [HttpPost]
        public JsonResult Sil(int Id)
        {
            Kategori kategoriDB = _kategoriRepository.GetById(Id);
            if (kategoriDB==null)
            {
                return Json(new ResultJson { Success = false, Message = "Böyle bir kategori  bulunamadı!" });
            }
            else
            {
                _kategoriRepository.Delete(Id);
                _kategoriRepository.Save();
                return Json(new ResultJson {Success=true,Message="Kategori silindi.." });
            }

          
        }
        #endregion

        #region SetKategori
        public void SetKategoriListele()
        {
            var kategoriList = _kategoriRepository.GetMany(x=>x.ParentID==0).ToList();
            ViewBag.Kategori = kategoriList;
        }


        #endregion

        #region KategoriWorkFlow
        public void WorkFlow()
        {
            var workflow = _kategoriRepository.GetAll().ToList();
            ViewBag.Workflow = workflow;
        }
        #endregion
    }
}