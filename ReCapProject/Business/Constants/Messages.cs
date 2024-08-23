using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Produkt yükləndi";
        public static string ProductDeleted = "Produkt silindi";
        public static string ProductUpdated = "Produkt güncəlləndi";
        public static string ProductNameInvalid = "Produkt adı uyğun deyil";
        public static string MaintenanceTime = "Server temirdedir";
        public static string ProductsListed = "Produktlar listelendi";
        public static string TheCarWasNotReturned = "Avtomobil Geri Qaytarılmayıb";
        public static string ProductNameAlreadyExists = "Bu adda başqa bir maşın var";
        public static string FalseImageCount = "Maşının şəklinin sayı 5 - dən çox ola bilməz";
        public static string ImageNotFound = "Şəkil tapılmadı";
        public static string ImageDeleted = "Şəkil silindi";
        public static string ImagesListed = "Şəkillər listələndi";
        public static string ImagesAdded = "Şəkillər əlavə olundu";
        public static string ImagesUpdated = "Şəkillər yeniləndi";
        public static string UserRegistered = "Qeydiyyatdan keçdi";
        public static string UserNotFound = "İstifadəçi tapılmadı";
        public static string PasswordError = "Şifrə yanlışdır";
        public static string SuccessfulLogin = "Daxil oldunuz";
        public static string UserAlreadyExists = "Bu istifadəçi mövcuddur";
        public static string AccessTokenCreated = "Token yaradıldı";
    }
}
