using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;

using DataAccess.Abstract;

using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, CarRentalContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from oc in context.OperationClaims
                             join uoc in context.UserOperationClaims
                                 on oc.Id equals uoc.OperationClaimId
                             where uoc.UserId == user.Id
                             select new OperationClaim { Id = oc.Id, Name = oc.Name };
                return result.ToList();
            }

            
        }
    }
}
