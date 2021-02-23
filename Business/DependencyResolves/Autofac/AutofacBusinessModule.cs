using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntittFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolves.Autofac
{
    public class AutofacBusinessModule: Module //using Autofac; eklendi
    {
        protected override void Load(ContainerBuilder builder)
        {
            //Singleton için yeni sistem bu şekilde.
            // IProductService isteyene ProductManager ver diyoruz.
            //SingleInstance deger döndürmüyorsa bunu kullanıyoruz.

            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();
            builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();
        }
    }
}
