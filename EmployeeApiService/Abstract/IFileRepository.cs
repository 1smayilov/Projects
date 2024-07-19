using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApiService.Abstract
{
    public interface IFileRepository 
    {
        public Task<string> FileUpload(string rootFolder, string folder, IFormFile file);
        public void FileDelete(string rootFolder, string folder, string file);
    }
}
