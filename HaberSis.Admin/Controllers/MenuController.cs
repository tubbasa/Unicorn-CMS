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

namespace HaberSis.Admin.Controllers
{

  
    public class MenuController : Controller
    {
        #region ctor

        private readonly IMenuRepository _menurepository;
        private readonly IMenuLabelRepository _menulabelrepository;
    private readonly IMenuTipRepository _menutiprepository;
        private readonly IMenuElemanlariRepository _menuelemanrepository;
        private readonly IKategoriRepository _kategorirepository;


        public MenuController(IMenuRepository menurepository, IMenuLabelRepository menulabelrepository, IMenuTipRepository menutiprepository, IMenuElemanlariRepository menuelemanlarirepository , IKategoriRepository kategorirepository )
        {
            this._menuelemanrepository = menuelemanlarirepository;
            this._menulabelrepository = menulabelrepository;
            this._menurepository = menurepository;
            this._menutiprepository = menutiprepository;
            this._kategorirepository = kategorirepository;
        }
        #endregion
        // GET: Menu
        public ActionResult Index()
        {
            return View();
        }
        #region MenuTipEkle
        [HttpGet]
        [LoginFilter]
        public ActionResult MenuTipEkle()
        {
            return View();
        }

        [HttpPost]
        public JsonResult MenuTipEkle(MenuTip menutip)
        {
            try
            {
                _menutiprepository.Insert(menutip);
                _menutiprepository.Save();
                TempData["Bilgi"] = "Menü Tipi Eklendi..";
                return Json(new ResultJson {Success=true,Message = "Menü Tipi Eklendi" });
            }
            catch (Exception)
            {

                return Json(new ResultJson { Success = false, Message = "Menü Tipi Eklenemedi" });
            }
            
        }
        #endregion

        #region MenuTipListele
        [HttpGet]
        [LoginFilter]
        public ActionResult MenuTipListele(int sayfa=1)
        {
            var menutiplist = _menutiprepository.GetAll().OrderByDescending(x => x.ID).ToPagedList(sayfa, 10);
            return View(menutiplist);
        }

        #endregion

        #region MenuTipSil
        
        public JsonResult MenuTipSil(MenuTip menutip)
        {
            try
            {
                var silinecek = _menutiprepository.GetById(menutip.ID);
                _menutiprepository.Delete(silinecek.ID);
                _menutiprepository.Save();
                return Json(new ResultJson { Success = true, Message = "Menü tipi silindi.." });

            }
            catch (Exception e)
            {

                return Json(new ResultJson { Success = true, Message = "Menü tipi silinemedi.. Hata:"+e });
            }
         

        }

        #endregion

        #region MenuTipDuzenle
        [HttpGet]
        [LoginFilter]
        public ActionResult MenuTipDuzenle(int Id)
        {
            var secilenmenutip = _menutiprepository.GetById(Id);
            return View(secilenmenutip);
        }

        [HttpPost]
        public JsonResult MenuTipDuzenle(MenuTip menutip)
        {
            var secilimenutip = _menutiprepository.GetById(menutip.ID);
            secilimenutip.TipAdi = menutip.TipAdi;
            secilimenutip.AktifMi = menutip.AktifMi;
        
            _menutiprepository.Save();
            return Json(new ResultJson { Success = true, Message = "Düzenleme işlemi başarılı" });
            
        }
        #endregion

        #region MenuEkle
        [HttpGet]
        [LoginFilter]
        public ActionResult MenuEkle()
        {
            ViewBag.MenuTip = _menutiprepository.GetAll();
            return View();
        }

        [HttpPost]
        public JsonResult MenuEkle(Menu menu,int? MenuTipi_ID)
        {
            try
            {
              
                _menurepository.Insert(menu);
                _menurepository.Save();
                return Json(new ResultJson {Success=true,Message="Menu başarılı bir şekilde eklendi.." });
            }
            catch (Exception e)
            {

                return Json(new ResultJson { Success = true, Message = "Menu eklenirken bir hata oluştu, hata:"+e });
            }
           
        }
        #endregion

        #region MenuListele
        [HttpGet]
        public ActionResult MenuListele(int sayfa=1)
        {
            var menuler = _menurepository.GetAll().OrderByDescending(x => x.ID).ToPagedList(sayfa, 10); 
            return View(menuler);
        }

        #endregion

        #region MenuDuzenle

        [HttpGet]
        [LoginFilter]
        public ActionResult MenuDuzenle(int MenuId)
        {
            ViewBag.MenuTip = _menutiprepository.GetAll();
            var duzenlenecek = _menurepository.GetById(MenuId);

            return View(duzenlenecek);
        }
        [HttpPost]
        public JsonResult MenuDuzenle(Menu menu)
        {
            try
            {
                var duzenle = _menurepository.GetById(menu.ID);
                duzenle.MenuAdi = menu.MenuAdi;
                duzenle.MenuTipiId = menu.MenuTipiId;
                duzenle.AktifMi = menu.AktifMi;
                _menurepository.Save();
                return Json(new ResultJson { Success=true,Message="Menu başarılı bir şekilde düzenlendi"});
            }
            catch (Exception e)
            {

                return Json(new ResultJson { Success = true, Message = "Menu başarılı düzenlenirken bir hata oluştu"+e });
            }

          
        }
        #endregion

        #region MenuSil

        public JsonResult MenuSil(Menu menu)
        {
            try
            {
                _menurepository.Delete(menu.ID);
                _menurepository.Save();
                return Json(new ResultJson { Success=false,Message="Menu başarılı bir şekilde silindi."});
            }
            catch (Exception e)
            {

                return Json(new ResultJson { Success = false, Message = "Menu silinirken bir hata oluştur. "+e });
            }
          
        }
        #endregion
     

        #region MenuLabelEkle
        [HttpGet]
        [LoginFilter]
        public ActionResult MenuLabelEkle()
        {
            return View();
        }

        [HttpPost]
        [LoginFilter]
        public JsonResult MenuLabelEkle(MenuLabel menulabel)
        {
            try
            {
                _menulabelrepository.Insert(menulabel);
                _menulabelrepository.Save();
                return Json(new ResultJson {Success=true,Message="Menü label eklendi" });
            }
            catch (Exception e)
            {

                return Json(new ResultJson {Success=false,Message="Menü label elkeme hatası:"+e });
            }
       
        }

        #endregion

        #region  MenuLabelListele
        [HttpGet]
        [LoginFilter]
        public ActionResult MenuLabelListele(int sayfa=1)
        {
            var labels = _menulabelrepository.GetAll().OrderByDescending(x => x.ID).ToPagedList(sayfa, 10);
            return View(labels);
        }
        #endregion

        #region  MenuLabelDuzenle

        [HttpGet]
        [LoginFilter]
        public ActionResult MenuLabelDuzenle(int Id)
        {
            var label=_menulabelrepository.GetById(Id);
            return View(label);
        }

        public JsonResult MenuLabelDuzenle(MenuLabel menulabel)
        {
            try
            {
                var duzenlenecek = _menulabelrepository.GetById(menulabel.ID);
                duzenlenecek.Ad = menulabel.Ad;
                duzenlenecek.Aciklama = menulabel.Aciklama;
                duzenlenecek.AktifMi = menulabel.AktifMi;
                _menulabelrepository.Save();
                return Json(new ResultJson { Success=true,Message="Menu label düzenleme işlemi başarılı.."});
            }
            catch (Exception e)
            {

                return Json(new ResultJson { Success = true, Message = "Menu label düzenleme işlemi başarısız"+e });
            }
          
        }
        #endregion

        #region  MenuLabelSil

        public JsonResult MenuLabelSil(MenuLabel menulabel)
        {
            try
            {
                _menulabelrepository.Delete(menulabel.ID);
                _menulabelrepository.Save();
                return Json(new ResultJson { Success=true,Message="Menü Label'ı başarıyla silindi"});
            }
            catch (Exception e)
            {

                return Json(new ResultJson { Success = true, Message = "Menü Label'ı silinemedi, hata:"+e });
            }
        }
        #endregion

        public ActionResult MenuElemanEkle()
        {
            return View();
        }
        public ActionResult MenuElemanListele()
        {
            return View();
        }

        [HttpPost]
        public JsonResult MenuListe()
        {
        
            var liste = _menurepository.GetAll().ToList();
            var ListSTR = "";
            foreach (var item in liste)
            {
                ListSTR += "Ad:" + item.MenuAdi +" , "+item.MenuTipi.TipAdi+ "-ID:" + item.ID + "|";
            }
            return Json(ListSTR);
        }

        public ActionResult MenuRedirect(int Id)
        {
           
                var menu = _menurepository.GetById(Id);
                if (menu.MenuTipi.TipAdi == "Ana Menü")
                {

                return RedirectToAction("AnaMenuElemanEkle", "Menu", new { MenuId = Id });
                }
                else if (menu.MenuTipi.TipAdi == "Extra Menü")
                {
                return RedirectToAction("ExtraMenuElemanEkle", "Menu", new { MenuId = Id });
               
                }
                else if (menu.MenuTipi.TipAdi == "Yan Menü")
                {
                return RedirectToAction("YanMenuElemanEkle", "Menu", new { MenuId = Id });
                
                }
            else
            {
                return null;
            }
          
         
        }

        #region Anamenuelemanislemleri
        #region anamaenuelemanekle
        [HttpGet]
        [LoginFilter]
        public ActionResult AnaMenuElemanEkle(int? elemanId,int MenuId)
        {
            if (elemanId!=null)
            {
                ViewBag.Eleman = elemanId;


            }
            else
            {
                ViewBag.MenuId = MenuId;
            }
            ViewBag.Sabit = null;//sabit sayfalar gelecek
            ViewBag.Kategoriler = _kategorirepository.GetMany(x=>x.AktifMi==true).ToList();
            return View();
        }
        [HttpPost]
        public ActionResult AnaMenuElemanEkle(string Baslik, string UrlKEY, int? MenuId, int? elemanId, bool AktifMi)
        {
            if (elemanId!=null)
            {
              var eklenecekeleman=  _menuelemanrepository.GetById(Convert.ToInt32(elemanId));
                MenuElemanlari menueleman = new MenuElemanlari();
                menueleman.Baslik = Baslik;
                menueleman.UrlKEY = UrlKEY;
                menueleman.ParentId = Convert.ToInt32(elemanId);
                menueleman.AktifMi = AktifMi;
                menueleman.MenuId = Convert.ToInt32(eklenecekeleman.MenuId);
                _menuelemanrepository.Insert(menueleman);
                _menuelemanrepository.Save();
            }
            else
            {
                MenuElemanlari menueleman = new MenuElemanlari();
                menueleman.Baslik = Baslik;
                menueleman.UrlKEY = UrlKEY;
                menueleman.ParentId = 0;
                menueleman.AktifMi = AktifMi;
                menueleman.MenuId = Convert.ToInt32(MenuId);
                _menuelemanrepository.Insert(menueleman);
                _menuelemanrepository.Save();
                //burası
                //anamenu eklenir
            }
            return null;
        }
        #endregion
        #region anamenuelemanlistele
        [HttpGet]
        public ActionResult AnaMenuElemanListele(int? elemanID,int? MenuId,int sayfa=1)
        {
            
              var list=  _menurepository.GetAll().OrderByDescending(x => x.ID).ToPagedList(sayfa, 10);
                ViewBag.AllMenus = true;
             
                return View(list);
           
         
        }

        public ActionResult MenuSubList(int MenuId,int sayfa=1)
        {
            ViewBag.MenuDetails = _menurepository.GetById(MenuId);
            //burası anamenuelemanlarının listelendiği yer
            var elemanlari = _menurepository.MenuElemanlariniGetir(MenuId);
            var filtre = elemanlari.Where(x=>x.ParentId==0).OrderByDescending(x => x.ID).ToPagedList(sayfa, 10);
            ;
            return View(filtre);
        }

        public ActionResult SubMenusList(int elemanID,int sayfa=1)
        {
            //3.dallanma mı?
            var first = _menuelemanrepository.GetById(elemanID).ParentId;
            if (first!=0)
            {
                ViewBag.Third = true;
                //var second = _menuelemanrepository.GetById(first).ParentId;
                //if (second!=0)
                //{
                //    //3.olur
                //}
            }
            

            var eleman = _menuelemanrepository.GetById(elemanID);
            var menu = _menurepository.GetById(eleman.MenuId);
            ViewBag.MenuDetails = menu;
            ViewBag.ParentDetay = eleman;
            ViewBag.SubMenu = true;
            var elemanlari = _menuelemanrepository.GetMany(x => x.ParentId == elemanID).OrderByDescending(x => x.ID).ToPagedList(sayfa, 10); ;
        
            return View(elemanlari);
            //burada elemanın alt menuleri listelenecek
           
        }
        #endregion
        #region anamenuelemanduzenle
        [HttpGet]
        public ActionResult MenuElemanDuzenle(int elemanID)
        {
            ViewBag.Kategoriler = _kategorirepository.GetAll();
            var eleman = _menuelemanrepository.GetById(elemanID);
            return View(eleman);
        }

     
         

        [HttpPost]
        public ActionResult MenuElemanDuzenle(string Baslik, string UrlKEY,  int elemanId, bool AktifMi)
        {
            try
            {
                var duzenlenen = _menuelemanrepository.GetById(elemanId);
                duzenlenen.Baslik = Baslik;
                duzenlenen.AktifMi = AktifMi;
                duzenlenen.UrlKEY = UrlKEY;
                duzenlenen.MenuId = duzenlenen.MenuId;
                duzenlenen.ParentId = duzenlenen.ParentId;

                _menuelemanrepository.Save();
                return Json(new ResultJson { Success = true, Message = "Menu başarılı bir şekilde düzenlendi" });
            }
            catch (Exception e)
            {

                return Json(new ResultJson { Success = true, Message = "Menu başarılı düzenlenirken bir hata oluştu" + e });
            }
        }
        #endregion

        //#region MenuDuzenle
        //public ActionResult MenuDuzenle(int MenuID)
        //{
        //    return View();
        //}
        //#endregion
        #region anamenuelemansil

            [HttpPost]
        public JsonResult ElemanSil(int elemanId)
        {
            try
            {
                var submenus = _menuelemanrepository.GetMany(x=>x.ParentId==elemanId);
                List<int> listsub = new List<int>();
                if (submenus!=null)
                {
                    foreach (var item in submenus)
                    {
                        listsub.Add(item.ID);
                    }
                    foreach (var item in listsub)
                    {
                        _menuelemanrepository.Delete(item);
                    }
                }
                
                _menuelemanrepository.Delete(elemanId);
                _menuelemanrepository.Save();
                return Json(new ResultJson { Success=true,Message="Başarılı bir şekilde silindi"});
            }
            catch (Exception)
            {

                return Json(new ResultJson { Success = false, Message = "Bir hata oluştu" });
            }
        }
        #endregion
        #endregion
        public ActionResult ExtraMenuElemanEkle(int Id)
        {
            return View(Id);
        }
        public ActionResult YanMenuElemanEkle(int Id)
        {
            return View(Id);
        }


    }
}