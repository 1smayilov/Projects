using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers
{
    public class FileHelper
    {
        public static string SaveImage(IFormFile file)
        {
            string directory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images"); // Faylın yolunu yaradırıq

            if (!Directory.Exists(directory)) // Qovluğun olub-olmamasını yoxlayır
            {
                Directory.CreateDirectory(directory);
            }

            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName); // Fayl üçün unikal ad yaradır və birləşdirir
            string filePath = Path.Combine(directory, fileName); // Fayl üçün tam yol yaradılır ki, bu yolla fayl saxlanılacaq.

            using (var stream = new FileStream(filePath, FileMode.Create)) // Faylı təyin edilən yola kopyalayırıq.
            {
                file.CopyTo(stream);
            }

            return fileName; // Fayl yükləndikdən sonra onun adını qaytarırıq.
        }
    }
}
