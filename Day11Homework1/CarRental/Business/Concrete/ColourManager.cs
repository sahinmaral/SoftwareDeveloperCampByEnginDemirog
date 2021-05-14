using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;

using Entities.Concrete;

namespace Business.Concrete
{
    public class ColourManager : IColourService
    {
        private IColourDal _colourDal;

        public ColourManager(IColourDal colourDal)
        {
            _colourDal = colourDal;
        }


        public IDataResult<List<Colour>> GetAll()
        {
            if (DateTime.Now.Hour==0)
            {
                return new ErrorDataResult<List<Colour>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Colour>>(_colourDal.GetAll());
        }

        public IDataResult<Colour> Get(Expression<Func<Colour, bool>> filter)
        {
            return new SuccessDataResult<Colour>(_colourDal.Get(filter), Messages.ColourRetrieved);
        }

        public IDataResult<Colour> GetById(int colourId)
        {
            return new SuccessDataResult<Colour>(_colourDal.Get(x => x.ColourId == colourId));
        }

        public IResult Insert(Colour colour)
        {
            if (colour.ColourName.Length<2)
            {
                return new ErrorResult(Messages.ColourNameInvalid);
            }
            _colourDal.Add(colour);
            return new SuccessResult(Messages.ColourAdded);
        }

        public IResult Update(Colour colour)
        {
            _colourDal.Update(colour);
            return new SuccessResult(Messages.ColourUpdated);
        }

        public IResult Delete(Colour colour)
        {
            _colourDal.Delete(colour);
            return new SuccessResult(Messages.ColourDeleted);
        }
    }
}
