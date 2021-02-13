using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categotyDal;

        public CategoryManager(ICategoryDal categotyDal)
        {
            _categotyDal = categotyDal;
        }

        public List<Category> GetAll()
        {
            //İş Kodları buraya yazılır.
            //Yetkileri var mı yok mu? Sayı yeterli mi gibi gibi, fiyat 100'den az mı
            return _categotyDal.GetAll();
        }

        //Select * from Categories where CategoryID=categoryId
        public List<Category> GetById(int categoryId)
        {
            return _categotyDal.GetAll(c => c.CategoryId == categoryId);
        }
    }
}
