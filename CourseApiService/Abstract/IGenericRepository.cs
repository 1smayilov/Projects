using CourseApiData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApiService.Abstract
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        public void Add(T entity);
        public List<T> GetAll();
        public T GetById(int id);
        public void Delete(T entity); 
    }
}
