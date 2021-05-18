﻿using System;
using System.Collections.Generic;
using System.Text;

using Entities.Concrete;

namespace Business.Constants
{
    public static class Messages
    {
        public static string MaintenanceTime = "Bakım yapılıyor";
        public static string ColourNameInvalid = "Renk adı geçersiz";
        public static string BrandNameInvalid = "Marka adı geçersiz";
        public static string CarNameInvalid = "Araba adı geçersiz";
        public static string RentalCarNotAvailable = "Kiralayacağınız araba daha teslim edilmemiş";
        public static string ReturnDateCannotBeNull = "Kiralayacağınız arabanın teslim tarihi olması gerekir";
        public static string RentalDayLessThanZero = "Kiralayacağınız arabanın teslim ve alım tarihi sıfırdan büyük olması gerekir";
        public static string NoSelectedCarsOnRented = "Seçtiğiniz araba zaten kiralanmamış";
        public static string CarIdRequired = "Arabanin Id sini girmeniz gerekir";
        public static string CarImagesLimitExceeded =
            "Araba resmi limiti aşıldığı için işlem gerçekleşmiyor";
        public static string CarNotExisted = "Araba bulunamadı";
        public static string CarPhotoNotExisted = "Arabanın fotoğrafı bulunamadı";
        public static string SuccessfullyAdded = "Başarıyla eklendi";
        public static string SuccessfullyRetrieved = "Başarıyla getirildi";
        public static string SuccessfullyDeleted = "Başarıyla silindi";
        public static string SuccessfullyUpdated = "Başarıyla güncellendi";

    }
}
