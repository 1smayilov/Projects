using EmployeeApiService.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApiService.Concrete
{
    public class FileRepository : IFileRepository
    {
        public void FileDelete(string rootFolder, string folder, string file)
        {
            string fullPath = Path.Combine(rootFolder, folder, file);
            if(File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }
        }

        public async Task<string> FileUpload(string rootFolder, string folder, IFormFile file)
        {
            string folderPath = Path.Combine(rootFolder, folder); // wwwroot/employee/
            string fileName = Guid.NewGuid().ToString() + "_" + file.FileName; // image.png
            string fullPath = Path.Combine(folderPath, fileName); // wwwroot/employee/image.png
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            using(FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return fileName;
        }
    }
}
