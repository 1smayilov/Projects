using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApiData.Entities
{
    public class Positions : BaseEntity
    {
        [StringLength(10)]
        public string Name { get; set; }
    }
}
