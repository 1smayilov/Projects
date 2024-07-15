using EmployeeApiData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApiService.Abstract
{
    public interface IPositionsRepository : IGenericRepository<Positions>
    {
        public void Update(int id,Positions positions);
    }
}
