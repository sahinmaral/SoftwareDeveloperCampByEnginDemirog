using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IBrandService
    {
        IDataResult<List<Brand>> GetAll();
        IDataResult<Brand> Get(Expression<Func<Brand, bool>> filter);
        IDataResult<Brand> GetById(int entityId);
        IResult Insert(Brand entity);
        IResult Update(Brand entity);
        IResult Delete(Brand entity);
    }
}
