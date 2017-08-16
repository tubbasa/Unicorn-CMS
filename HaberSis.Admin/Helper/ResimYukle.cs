using HaberSis.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaberSis.Admin.Helper
{
    public static class ResimYukle<T>
    {
        public static string Resim(HttpPostedFileBase ResimUrl, T tip)
        {
            string dosyaadi = Guid.NewGuid().ToString().Replace("-","");
            string[] uzanti = ResimUrl.ContentType.Split('/');
            var sliderise = tip is Slider;
            var haberise = tip is Haber;
            string tamyolYeri;
            Slider slider= new Slider { };
            Haber haber= new Haber { };


            if (sliderise==true)
            {
                tamyolYeri=  "/External/Slider/" + dosyaadi + "." + uzanti[1];
                slider = tip as Slider;
            }
            else
            {
                haber = tip as Haber;
                tamyolYeri = "/External/Haber/" + dosyaadi + "." + uzanti[0];
            }
          
            ResimUrl.SaveAs(System.Web.HttpContext.Current.Server.MapPath(tamyolYeri));
            slider.ResimUrl = tamyolYeri;
            return slider.ResimUrl;
         
       

            return null;
        }
    }
}