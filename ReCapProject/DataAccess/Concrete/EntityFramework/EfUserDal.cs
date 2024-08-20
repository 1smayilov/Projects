using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, ReCapContext>, IUserDal 
    {
        public List<OperationClaim> GetClaims(User user) // Rolun Id sini və Adını saxlayır
        {
            using(var context = new ReCapContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                             on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where user.Id == userOperationClaim.UserId
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();
            }
        }
    }
}

//          var claims = new List<Claim>
//          {
//              new Claim(ClaimTypes.Name, user.Name),
//              new Claim(ClaimTypes.Email, user.Email),
//              new Claim(ClaimTypes.Role, "Admin")
//          };

