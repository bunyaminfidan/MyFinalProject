
using Business.Concrete;
using DataAccess.Concrete.EntittFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    //SOLID O Harfi: Open Closed Principle Yeni özelllik ekliyorsan mevcuttaki koduna dokunmayacaksın
    //DTO Data Transformation Object join kullanarak yazılan sql sorgusu

    class Program
    {
        static void Main(string[] args)
        {
            ProductTest();
            //CategoryGetAllTest();


        }

        private static void CategoryGetAllTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());


            foreach (var category in categoryManager.GetAll().Data)
            {
                Console.WriteLine(category.CategoryName);

            }
        }

        private static void ProductTest()
        {

            ProductManager productManager = new ProductManager(new EfProductDal(),
                new CategoryManager( new EfCategoryDal()));
            var result = productManager.GetProductDetails();

            if (result.Success)
            {
                foreach (var product in result.Data)
                {
                    Console.WriteLine(product.ProductName + " / " + product.CategoryName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }


    }
}
