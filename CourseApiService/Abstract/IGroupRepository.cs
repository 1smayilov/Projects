using CourseApiData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApiService.Abstract
{
    public interface IGroupRepository : IGenericRepository<Group>
    {
        public void Update(int id, Group group);
    }
}
