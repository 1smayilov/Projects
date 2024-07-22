using CourseApiData.Entities;
using CourseApiService.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApiService.Concrete
{
    public class GroupRepository : GenericRepository<Group>, IGroupRepository
    {
        public GroupRepository(ApplicationDbContext context) : base(context)
        {
        }
        public void Update(int id, Group group)
        {
            Group groupDb = GetById(id);
            if (groupDb != null)
            {
                groupDb.Name = group.Name;
                groupDb.UpdateAt = DateTime.Now;
                _context.SaveChanges();
            }
            _context.SaveChanges();
        }
    }
}
