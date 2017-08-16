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
using System.IO;
using System.Text;

namespace HaberSis.Admin.Controllers
{
    public class HaberController : Controller
    {
        #region ctor
        private readonly IHaberRepository _haberrepository;
        private readonly IKategoriRepository _kategorirepository;
        private readonly IKullaniciRepository _kullanicirepository;
        private readonly IResimRepository _resimrepository;
        private readonly IEtiketRepository _etiketRepository;
        public HaberController(IHaberRepository haberrepository, IKategoriRepository kategorirepository,IKullaniciRepository kullanicirepository,IResimRepository resimrepository, IEtiketRepository etiketRepository)
        {
            this._haberrepository = haberrepository;
            this._kategorirepository = kategorirepository;
            this._kullanicirepository = kullanicirepository;
            this._resimrepository = resimrepository;
            this._etiketRepository = etiketRepository;
        }

        #endregion
        // GET: Haber
        #region Listele
        [LoginFilter]
        [HttpGet]
        public ActionResult Index(int sayfa=1)
        {

            return View(_haberrepository.GetAll().OrderByDescending(x=>x.ID).ToPagedList(sayfa,10));
        }

        #endregion

        #region Ekle


        [HttpGet]
        [LoginFilter]
        public ActionResult Ekle()
        {
            setKategoriListele();
            return View();
        }

        [HttpPost]
        [LoginFilter]
        public ActionResult Ekle(Haber haber,int KategoriId, HttpPostedFileBase VitrinResmi,IEnumerable<HttpPostedFileBase> DetayResim , string Etiket)
        {
            var SessionControl = HttpContext.Session["KullaniciEmail"];
            if (haber!=null) //haberclası içine yazdııpmız özellikler tamam ise demek. requiredlar mesela
            {
                Kullanici kullanici = _kullanicirepository.Get(x=>x.Email==SessionControl.ToString());
                haber.KullaniciId = kullanici.ID;
                haber.KategoriId = KategoriId;
                if (VitrinResmi!=null)
                {
                    string DosyaAdi = Guid.NewGuid().ToString().Replace("-","");
                    string Uzanti = System.IO.Path.GetExtension(Request.Files[0].FileName);
                    string Tamyol = "/External/Haber/" + DosyaAdi + Uzanti;
                    Request.Files[0].SaveAs(Server.MapPath(Tamyol));
                    haber.Resim = Tamyol;
                }

           
                _haberrepository.Insert(haber);
                _haberrepository.Save();
              
                _etiketRepository.EtiketEkle(haber.ID, Etiket);
                var haberId = haber.ID;
                string CokluResim = System.IO.Path.GetExtension(Request.Files[1].FileName);

                if (CokluResim != "")
                {
                    foreach (var file in DetayResim)
                    {
                        if (file.ContentLength>0)
                        {
                            string DosyaAdi = Guid.NewGuid().ToString().Replace("-", "");
                            string Uzanti = System.IO.Path.GetExtension(Request.Files[1].FileName);
                            string Tamyol = "/External/Haber/" + DosyaAdi + Uzanti;
                            file.SaveAs(Server.MapPath(Tamyol));

                            var resim = new Resim { ResimUrl=Tamyol};
                            resim.HaberId = haber.ID;

                            _resimrepository.Insert(resim);
                            _resimrepository.Save();
                        }
                    }
                }


            }
            //return Json(new ResultJson { Success = true, Message = ""});
            TempData["Bilgi"] = "Haber ekleme işleminiz başarılı";
            return RedirectToAction("Index");
        }
        #endregion

        #region Sil

    
 
        public ActionResult Sil(int Id)
        {
            Haber dbHaber = _haberrepository.GetById(Id);
            var dbDetayResim = _resimrepository.GetMany(X=>X.HaberId==Id);
            if (dbHaber==null)
            {
                throw new Exception("Haber Bulunamadı");
            }
            else
            {
               
                string fileName = dbHaber.Resim;
                string path = Server.MapPath(fileName);
                FileInfo file = new FileInfo(path);
                if (file.Exists)  //dosyanın varlığı kontrol ediliyor
                {
                    file.Delete();
                }
                TempData["Bilgi"] = "Haber başarılı bir şekilde silindi";
            }

            if (dbDetayResim != null)
            {
                foreach (var res in dbDetayResim)
                {
                    string detayPath = Server.MapPath(res.ResimUrl);
                    FileInfo resim = new FileInfo(detayPath);
                    if (resim.Exists)
                    {
                        resim.Delete();
                    }
                   
                }
            }
            _haberrepository.Delete(Id);
            _haberrepository.Save();
            return RedirectToAction("Index","Haber");
        }




        #endregion

        #region Durum Değiştir

        public ActionResult Durum(int Id, bool Durum)
        {
            var Haber = _haberrepository.GetById(Id);
            if (Durum==true) //pasif edeceğiz
            {
                Haber.AktifMi = false;
            }
            else
            {
                Haber.AktifMi = true;
            }

            _haberrepository.Save();

            return RedirectToAction("Index","Haber");
        }

        #endregion

        #region Düzenle

        [HttpGet]
        [LoginFilter]
        public ActionResult Duzenle(int Id)
        {
            Haber gelenHaber = _haberrepository.GetById(Id);
            #region Etiket
            var gelenEtiket = gelenHaber.Etiket.Select(x => x.EtiketAdi).ToArray();
            HaberEtiketModel model = new HaberEtiketModel
            {
                Haber = gelenHaber,
                Etiketler = _etiketRepository.GetAll(),
                GelenEtiketler = gelenEtiket
            };
            StringBuilder birlestir = new StringBuilder();
            foreach (var etiket in model.GelenEtiketler)
            {
                birlestir.Append(etiket.ToString());
                birlestir.Append(",");
            }
            model.EtiketAd = birlestir.ToString();

            #endregion

            if (gelenHaber==null)
            {
                throw new Exception("Haber Bulunamadı");
            }
            else
            {
                setKategoriListele();
                return View(model);
            }
         

        }

        [HttpPost]
        [LoginFilter]
        public ActionResult Duzenle(Haber haber,HttpPostedFileBase VitrinResmi,IEnumerable<HttpPostedFileBase> DetayResim, string EtiketAd)
        {
            Haber gelen = _haberrepository.GetById(haber.ID);
            gelen.Aciklama = haber.Aciklama;
            gelen.Baslik = haber.Baslik;
            gelen.KategoriId = haber.KategoriId;
            gelen.KisaAciklama = haber.KisaAciklama;
            gelen.AktifMi = haber.AktifMi;

            if (VitrinResmi != null)
            {
                string dosyaAdi = gelen.Resim;
                string dosyaYolu = Server.MapPath(dosyaAdi);
                FileInfo file = new FileInfo(dosyaYolu);
                if (file.Exists)
                {
                    file.Delete();
                }

                string fileName = Guid.NewGuid().ToString().Replace("-","");
                string uzanti = System.IO.Path.GetExtension(Request.Files[0].FileName);
                string Tamyol = "/External/Haber/"+fileName+uzanti;
                Request.Files[0].SaveAs(Server.MapPath(Tamyol));
                gelen.Resim = Tamyol;
                

            }
            string cokluResim = System.IO.Path.GetExtension(Request.Files[1].FileName);
            if (cokluResim != "")
            {
               
                foreach (var item in DetayResim)
                {
                    
                    string dosyaAdi = Guid.NewGuid().ToString().Replace("-","");
                    string uzanti = System.IO.Path.GetExtension(Request.Files[1].FileName);
                    string Tamyol = "/External/Haber/" + dosyaAdi + uzanti;
                    item.SaveAs(Server.MapPath(Tamyol));
      
                    var img = new Resim { ResimUrl=Tamyol,HaberId=gelen.ID,EklenmeTarihi=DateTime.Now};
                    _resimrepository.Insert(img);
                    _resimrepository.Save();
        
                }
                
            }
            _etiketRepository.EtiketEkle(haber.ID, EtiketAd);
            _haberrepository.Save();
            TempData["Bilgi"] = "Haber Düzenlendi";
           return RedirectToAction("Index","Haber");
        }

        #endregion

        #region TekliResimSilme


        public ActionResult resimSil(int ID)
        {
            var resim = _resimrepository.GetById(ID);
            if (resim!=null)
            {
                string file_name = resim.ResimUrl;
                string path = Server.MapPath(file_name);
                FileInfo file = new FileInfo(path);
                if (file.Exists)
                {
                    file.Delete();
                }
                _resimrepository.Delete(resim.ID);
                _resimrepository.Save();
            }

            return RedirectToAction("Duzenle","Haber",new { Id = resim.HaberId}); ;
        }
        #endregion

        #region Set Kategori Listesi

        public void setKategoriListele(object kategori=null)
        {
            var KategoriList = _kategorirepository.GetMany(x=>x.ParentID==0).ToList();
            ViewBag.Kategori = KategoriList;
        }
        #endregion
    }
}