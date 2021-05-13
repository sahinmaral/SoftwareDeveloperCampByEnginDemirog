using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IColourService
    {
        IDataResult<List<Colour>> GetAll();
        IDataResult<Colour> GetById(int colourId);
        IResult Insert(Colour colour);
        IResult Update(Colour colour);
        IResult Delete(Colour colour);
    }
}
