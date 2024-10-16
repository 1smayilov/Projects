using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract.AbstractUow
{
    public interface IGenericUowService<T>
    {
        T GetById(int id);
        void Insert(T entity);
        void Update(T entity);
        void MultiUpdate(List<T> entity);      
    }
}
