using EmployeeApiData.Entities;
using EmployeeApiService.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApiService.Concrete
{
    public class EmployeeInfoRepository : GenericRepository<EmployeeInfo>, IEmployeeInfoRepository
    {
        public EmployeeInfoRepository(ApplicationDbContext context) : base(context)
        {
        }
        public void Update(int id, EmployeeInfo employeeInfo)
        {
            EmployeeInfo employeeInfoDb = GetById(id);
            if (employeeInfoDb != null)
            {
                employeeInfoDb.Birthday = employeeInfo.Birthday;
                employeeInfoDb.Firstname = employeeInfo.Firstname;
                employeeInfoDb.Lastname = employeeInfo.Lastname;
                employeeInfo.Image = employeeInfo.Image;
                _context.SaveChanges();

            }
        }
    }
}
