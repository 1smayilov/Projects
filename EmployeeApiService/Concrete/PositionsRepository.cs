using EmployeeApiData.Entities;
using EmployeeApiService.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApiService.Concrete
{
    public class PositionsRepository : GenericRepository<Positions>, IPositionsRepository
    {
        public PositionsRepository(ApplicationDbContext context) : base(context)
        {
        }

        public void Update(int id, Positions positions)
        {
            Positions positionDb = GetById(id);
            if(positionDb != null)
            {
                positionDb.Name = positions.Name;
                positionDb.UpdatedAt = positions.UpdatedAt;
                _context.SaveChanges();
            }
            _context.SaveChanges();
        }
    }
}
