﻿using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService
    {
        //IDataResult<T> ile message, success ve data aynı anda dönebiliyoruz.
        //IResult ile void işlemleri yapıyoruz.
        IDataResult<List<Product>> GetAll();
        IDataResult<List<Product>> GelAllByCategoryId(int id);
        IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max);
        IDataResult<List<ProductDetailDto>> GetProductDetails();
        IDataResult<Product> GetById(int productId);
        IResult Add(Product product);
        IResult Update(Product product);
        IResult Delete (Product product);


        //------//
        //Uygulamalarda tutarlılığı kontrol etmek için kullanılan yöntem
        //100 liram var eft yaptım
        //10 lira gönderdim benden düştü para
        //karşı tarafa para yyatmadı işlem iptal edilmesi gerekir.
        IResult AddTransactionalTest(Product product);
    }
}
