using Core.Utilities.Results;

using Entities.Concrete;

using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Business.Abstract
{
    public interface ICustomerService 
    {
        IDataResult<List<Customer>> GetAll();
        IDataResult<Customer> Get(Expression<Func<Customer, bool>> filter);
        IDataResult<Customer> GetById(int entityId);
        IResult Insert(Customer entity);
        IResult Update(Customer entity);
        IResult Delete(Customer entity);
    }
}
