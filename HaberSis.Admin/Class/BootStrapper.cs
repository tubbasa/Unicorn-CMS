using Autofac;
using Autofac.Integration.Mvc;
using HaberSis.Core.Repository;
using HaberSis.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HaberSis.Core;

namespace HaberSis.Admin.Class
{
    public class BootStrapper
    {
        //boot aşamasında çalışacak



            public static void RunConfig()
        {
            BuildAutoFac();
        }
        private static void BuildAutoFac()
        {
            var builder = new ContainerBuilder();
            //buraya register edicez buraya etmezsek çalışmaz 
            //yazılan her repository buraya register edilmeli yoksa şu hatayı alırız: 
            //None of the constructors found with 'Autofac.Core.Activators.Reflection.DefaultConstructorFinder' on type 'HaberSis.Admin.Controllers.HaberController' can be invoked with the available services and parameters:
            //Cannot resolve parameter 'HaberSis.Core.Infrastructure.IEtiketRepository etiketRepository' of constructor 'Void .ctor(HaberSis.Core.Infrastructure.IHaberRepository, HaberSis.Core.Infrastructure.IKategoriRepository, HaberSis.Core.Infrastructure.IKullaniciRepository, HaberSis.Core.Infrastructure.IResimRepository, HaberSis.Core.Infrastructure.IEtiketRepository)'.

            builder.RegisterType<HaberRepository>().As<IHaberRepository>();
            builder.RegisterType<ResimRepository>().As<IResimRepository>();
            builder.RegisterType<KullaniciRepository>().As<IKullaniciRepository>();
            builder.RegisterType<RolRepository>().As<IRolRepository>();
            builder.RegisterType<KategoriRepository>().As<IKategoriRepository>();
            builder.RegisterType<EtiketRepository>().As<IEtiketRepository>();
            builder.RegisterType<SliderRepository>().As<ISliderRepository>();

            builder.RegisterType<MenuRepository>().As<IMenuRepository>();
            builder.RegisterType<MenuLabelRepository>().As<IMenuLabelRepository>();
            builder.RegisterType<MenuTipRepository>().As<IMenuTipRepository>();
            builder.RegisterType<MenuElemanlariRepository>().As<IMenuElemanlariRepository>();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);



            




            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }
    }
}