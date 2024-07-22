using CourseApiData.Entities;
using CourseApiService.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApiService.Concrete
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected ApplicationDbContext _context;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            entity.DeletedAt = DateTime.Now;
            _context.SaveChanges();
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList().Where(x => x.DeletedAt == null).ToList(); 
        }

        public T GetById(int id)
        {
            return _context.Set<T>()
                .Where(x=>x.DeletedAt == null)
                .FirstOrDefault(x=>x.Id == id); 
        }
    }
}
