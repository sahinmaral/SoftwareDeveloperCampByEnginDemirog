using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IServiceBase<T>
    {
        IDataResult<List<T>> GetAll();
        IDataResult<T> GetById(int entityId);
        IResult Insert(T entity);
        IResult Update(T entity);
        IResult Delete(T entity);
    }
}
