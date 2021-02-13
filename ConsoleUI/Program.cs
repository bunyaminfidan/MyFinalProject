
using Business.Concrete;
using DataAccess.Concrete.EntittFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    //SOLID O Harfi: Open Closed Principle Yeni özelllik ekliyorsan mevcuttaki koduna dokunmayacaksın

    class Program
    {
        static void Main(string[] args)
        {
            // ProductTest();
            CategoryGetAllTest();

        }

        private static void CategoryGetAllTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var category in categoryManager.GetAll())
            {
                Console.WriteLine(category.CategoryName);

            }
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());

            foreach (var product in productManager.GetByUnitPrice(1, 200))
            {
                Console.WriteLine(product.ProductName);
            }
        }
    }
}
