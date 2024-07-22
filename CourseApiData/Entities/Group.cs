using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApiData.Entities
{
    public class Group : BaseEntity
    {
        [StringLength(10)]
        public string Name { get; set; }
    }
}
