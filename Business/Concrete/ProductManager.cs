using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService


    {

        //Constractır Oluşturuldu.
        //Newleme yapılmadı. Bu şekilde direk DataAccess kısmına erişim sağlanıyor.
        IProductDal _productDal;
        //category tablosunu ilgilendiren kuralda service enjekte edilir. ....Dal değil.
        ICategoryService _categoryService;

        //Bir manager kendşis haricinde başka bir ...Dal'ı enjekte edemez.
        public ProductManager(IProductDal productDal, ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
        }

        [SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            //business codes

            //validation : doğrulama kodu: yapısaal olarak iş koduna göndermeye müsait mi ona bakar.
            //business : iş kodu İş gereksinimlerine uygunluk. Ehliyet alacak gerekli kontrol.Sınavdan geçmiş mi.


            //if (product.UnitPrice<=0)
            //{
            //    return new ErrorResult(Messages.UnitPriceInValid);
            //}
            //if (product.ProductName.Length < 2)
            //{
            //    //magic string: stringleri ayrı yarı yazmak
            //    return new ErrorResult(Messages.ProductNameInValid);
            //}  
            //YERİNE fluentvalidation kullanıldı.

            // ValidationTool.Validate(new ProductValidator(), product);

            //bu result kurala uymayanı getiriyor
            //Polimorfizim var araştır.
            IResult result = BusinessRules.Run(
                CheckIfProductNameExists(product.ProductName),
                   CheckIfProductCountOfCategoryCorrect(product.CategoryId),
                   CheckIfCategoryLimitExceded());

            if (result != null)
            {
                return result;
            }

            _productDal.Add(product);

            return new SuccessResult(Messages.ProductAdded);
        }



        public IDataResult<List<Product>> GelAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
        }

        public IDataResult<List<Product>> GetAll()
        {
            //İş kodları buraya gelecek
            //Login olmuş ve yetkisi varsa artık DataAccess'a erişebilir.

            if (DateTime.Now.Hour == 15)
            {
                return new ErrorDataResult<List<Product>>(Messages.MainTenanceTime);
            }

            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductListed);

        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));

        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            //if (DateTime.Now.Hour == 00)
            //{
            //    return new ErrorDataResult<List<ProductDetailDto>>(Messages.MainTenanceTime);
            //}
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetail());
        }


        [ValidationAspect(typeof(ProductValidator))]
        public IResult Update(Product product)
        {
            throw new NotImplementedException();
        }
        //iş kuralı parçacığı olduğu için private sadece bu managerde
        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {
            //Select count(*) from products where categoryId=1
            //bu kodu çalıştırır.
            //Linq sorgusu
            var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count;
            if (result >= 10)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }

            return new SuccessResult();

        }

        //Any: kurala uyan var mı demek bool döner
        private IResult CheckIfProductNameExists(string productName)
        {
            var result = _productDal.GetAll(p => p.ProductName == productName).Any();
            if (result)
            {
                return new ErrorResult(Messages.ProductNameAllReadyExist);
            }
            return new SuccessResult();
        }

        private IResult CheckIfCategoryLimitExceded()
        {
            var result = _categoryService.GetAll();
            if (result.Data.Count > 15)
            {
                return new ErrorResult(Messages.CheckIfCategoryLimitExceded);
            }
            return new SuccessResult();
        }
    }
}
