using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;
using Entities.Concrete;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün eklendi";
        public static string ProductNameInvalid = "Ürün geçersiz";
        public static string MaintenanceTime = "Sistem bakımda";
        public static string ProductListed = "Ürünler listelendi";
        public static string UnitPriceInvalid = "Ürün fiyatı geçersiz";
        public static string ProductCategoryOverload =
            "Ürününüzün içerdiği kategori ürün sınırı aşıldığı için işlem yapılamaz";
        public static string ProductNameAlreadyExists = "Zaten böyle bir ürün adı içeren ürün vardır";
        public static string CategoryOverload = "Kategori sınırı aşıldğı için işlem yapılamaz";
        public static string AuthorizationDenied = "Bu işleme yetkiniz yoktur";
        public static string PasswordError = "Şifreniz yanlış";
        public static string SuccessfulLogin = "Başarıyla giriş yaptınız";
        public static string UserNotFound = "Kullanıcı bulunmadı";
        public static string UserRegistered = "Kullanıcı kayıt oldu";
        public static string UserAlreadyExists = "Kullanıcı zaten mevcut";
        public static string AccessTokenCreated = "Access token oluşturuldu";
        public static string ProductCountOfCategoryError = "Eklediğiniz ürün kategorisinin limiti doldu";
    }
}
