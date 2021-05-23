using Core.Utilities.Results;

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.Entities.Concrete;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserService 
    {
        IDataResult<List<User>> GetAll();
        IDataResult<User> Get(Expression<Func<User, bool>> filter);
        IDataResult<User> GetById(int entityId);
        IResult Insert(User entity);
        IResult Update(User entity);
        IResult Delete(User entity);
        IDataResult<List<OperationClaim>> GetClaims(User user);
        IDataResult<User> GetByMail(string email); 
    }
}
