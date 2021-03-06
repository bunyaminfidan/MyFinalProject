﻿using Business.Abstract;
using Core.Utilities.Results;
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

        public IDataResult<List<Category>> GetAll()
        {
            //İş Kodları buraya yazılır.
            //Yetkileri var mı yok mu? Sayı yeterli mi gibi gibi, fiyat 100'den az mı
            return new SuccessDataResult<List<Category>> (_categotyDal.GetAll());
        }

        //Select * from Categories where CategoryID=categoryId
        public IDataResult<Category> GetById(int categoryId)
        {
            return new SuccessDataResult<Category> (_categotyDal.Get(c => c.CategoryId == categoryId));
            
        }
    }
}
