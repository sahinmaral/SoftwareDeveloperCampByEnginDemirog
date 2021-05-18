using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
