using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    // Generic constraint - generic kisit
    // class - referans tip ola biler demekdir, ancaq IEntity in daxilinde olanlar
    //new() - new lene bilir olmalidir, IEntity olmasin deye bunu edirik ancaq daxilindekiler olsun
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        // Xüsusi məsələn categoriyası 2 olanları gətir, və yaxud adları bu olanları gətir
        List<T> GetAll(Expression<Func<T,bool>> filter=null);

        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
