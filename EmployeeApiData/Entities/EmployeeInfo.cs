using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApiData.Entities
{
    public class EmployeeInfo : BaseEntity
    {
        [StringLength(30)]
        public string Firstname { get; set; }
        [StringLength(30)]
        public string Lastname { get; set; }
        public DateTime Birthday{ get; set; }
        [StringLength(100)]
        public string Image { get; set; }
    }
}
