using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApiData.DTOs.EmployeeInfo
{
    public class EmployeeInfoPostDTO
    {
        [StringLength(50)]
        public string Firstname { get; set; }
        [StringLength(50)]
        public string Lastname { get; set; }
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }
        public IFormFile? File { get; set; }
    }
}
