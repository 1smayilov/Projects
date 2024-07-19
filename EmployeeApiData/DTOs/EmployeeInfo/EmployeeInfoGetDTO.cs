using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApiData.DTOs.EmployeeInfo
{
    public class EmployeeInfoGetDTO
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Image { get; set; }
        public DateTime Birthday { get; set; }
    }
}
