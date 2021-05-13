using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string MaintenanceTime = "Bakım yapılıyor";
        public static string CarAdded = "Araba eklendi";
        public static string ColourAdded = "Renk eklendi";
        public static string BrandAdded = "Marka eklendi";
        public static string ColourNameInvalid = "Renk adı geçersiz";
        public static string BrandNameInvalid = "Marka adı geçersiz";
        public static string CarNameInvalid = "Araba adı geçersiz";
        public static string ColourUpdated = "Renk güncellendi";
        public static string BrandUpdated = "Marka güncellendi";
        public static string CarUpdated = "Araba güncellendi";
        public static string ColourDeleted = "Renk silindi";
        public static string BrandDeleted = "Marka silindi";
        public static string CarDeleted = "Araba silindi";
        public static string CustomerAdded = "Müşteri Eklendi";
        public static string CustomerUpdated = "Müşteri Güncellendi";
        public static string CustomerDeleted = "Müşteri Silindi";
        public static string UserUpdated = "Kullanıcı güncellendi";
        public static string UserAdded = "Kullanıcı eklendi";
        public static string UserDeleted = "Kullanıcı silindi";
        public static string RentalDeleted = "Kiralama bilgisi silindi";
        public static string RentalUpdated = "Kiralama bilgisi güncellendi";
        public static string RentalAdded = "Kiralama bilgisi eklendi";
        public static string RentalCarNotAvailable = "Kiralayacağınız araba daha teslim edilmemiş";
        public static string ReturnDateCannotBeNull = "Kiralayacağınız arabanın teslim tarihi olması gerekir";
        public static string RentalDayLessThanZero = "Kiralayacağınız arabanın teslim ve alım tarihi sıfırdan büyük olması gerekir";
        public static string NoSelectedCarsOnRented = "Seçtiğiniz araba zaten kiralanmamış";
    }
}
