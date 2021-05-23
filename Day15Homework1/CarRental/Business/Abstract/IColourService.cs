using Core.Utilities.Results;

using Entities.Concrete;

using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Business.Abstract
{
    public interface IColourService 
    {

        IDataResult<List<Colour>> GetAll();
        IDataResult<Colour> Get(Expression<Func<Colour, bool>> filter);
        IDataResult<Colour> GetById(int entityId);
        IResult Insert(Colour entity);
        IResult Update(Colour entity);
        IResult Delete(Colour entity);
    }
}
