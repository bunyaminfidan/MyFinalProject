using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService


    {

        //Constractır Oluşturuldu.
        //Newleme yapılmadı. Bu şekilde direk DataAccess kısmına erişim sağlanıyor.
        IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public List<Product> GelAllByCategoryId(int id)
        {
            return _productDal.GetAll(p=>p.CategoryId==id);
        }

        public List<Product> GetAll()
        {
            //İş kodları buraya gelecek
            //Login olmuş ve yetkisi varsa artık DataAccess'a erişebilir.

            return _productDal.GetAll();

        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _productDal.GetAll(p=>p.UnitPrice >=min  && p.UnitPrice<=max);
        }
    }
}
