using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constans
{
    //static verilirse new'lemeye gerek yok.
    //tek ınstance oluyor.
    //Messages. diye kullanılır.

    //Değişken ama isimleri Pascal Case Çünkü public olduğu için.
    public static class Messages
    {
        public static string ProductAdded = "Ürün Eklendi";
        public static string ProductNameInValid = "Ürün ismi geçersiz";
        public static string MainTenanceTime = "Bakım zamanı";
        public static string ProductListed = "Ürünler listelendi";
        public static string UnitPriceInValid = "Ürün fiyatı ismi geçersiz";

    }
}
