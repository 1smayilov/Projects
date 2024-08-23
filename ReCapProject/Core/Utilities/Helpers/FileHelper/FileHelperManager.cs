using Core.Utilities.Helpers.FileHelper;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace Core.Utilities.Helpers
{
    public class FileHelperManager : IFileHelper
    {
        public void Delete(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        public string Update(IFormFile file, string filePath, string root)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            return Upload(file, root);
        }

        public string Upload(IFormFile file, string root)
        {
            if (file.Length > 0)
            {
                if (!Directory.Exists(root))
                {
                    Directory.CreateDirectory(root);
                }
                string extension = Path.GetExtension(file.FileName);
                string guid = Guid.NewGuid().ToString();
                string fileName = guid + extension;
                string filePath = Path.Combine(root, fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create)) 
                    // Əgər fayl mövcuddursa, köhnə fayl silinəcək və yerinə yeni fayl yaradılacaq.
                {
                    file.CopyTo(fileStream); // Göstərilən fayla köçürür
                }

                return fileName; // a1b2c3d4-e567-89f0-1234-56789abcdef0.jpg
            }
            return null;
        }
    }
}
