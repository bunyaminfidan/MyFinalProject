﻿using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
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
        public static string ProductUpdated = "Ürün Güncellendi";
        public static string ProductDeleted = "Ürün Silindi";
        public static string ProductNameInValid = "Ürün ismi geçersiz";
        public static string MainTenanceTime = "Bakım zamanı";
        public static string ProductListed = "Ürünler listelendi";
        public static string UnitPriceInValid = "Ürün fiyatı ismi geçersiz";
        public static string ProductCountOfCategoryError = "Ürün sayısı en fazla 10 olabilir";
        public static string ProductNameAllReadyExist = "Bu isimde zaten başka bir ürün var";
        public static string CheckIfCategoryLimitExceded = "Kategori limiti aşıldığı için yeni ürün eklenemiyor";

        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string UserRegistered = "Kayıt oldu";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Parola hatalı";
        public static string SuccessfulLogin = "Başarılı giriş";
        public static string UserAlreadyExists = "Kullanıcı mevcut";
        public static string AccessTokenCreated = "Token oluşturuldu";

        public static string UserAdded = "Kullanıcı eklendi";
        //public static string UserUpdated = "Kullanıcı güncellendi";
        //public static string UserDeleted = "Kullanıcı silinidi";
        //public static string GetAllUserListed = "Kullanıcılar listelendi";
        //public static string GetByUserIdListed = "Seçili kullanıcı listelendi";


    }
}
