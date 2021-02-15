using Business.Abstract;
using Business.Constans;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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

        public IResult Add(Product product)
        {
            //business kodlar buraya yaz

            if (product.ProductName.Length < 2)
            {
                //magic string: stringleri ayrı yarı yazmak
                return new ErrorResult(Messages.ProductNameInValid);
            }
            _productDal.Add(product);

            return new SuccessResult(Messages.ProductAdded);
        }

        public List<Product> GelAllByCategoryId(int id)
        {
            return _productDal.GetAll(p => p.CategoryId == id);
        }

        public IDataResult<List<Product>> GetAll()
        {
            //İş kodları buraya gelecek
            //Login olmuş ve yetkisi varsa artık DataAccess'a erişebilir.

            
            return new DataResult<List<Product>>(_productDal.GetAll(), true, "Ürünler Listelendi");

        }

        public Product GetById(int productId)
        {
            return _productDal.Get(p => p.ProductId == productId);

        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max);
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            return _productDal.GetProductDetail();
        }
    }
}
