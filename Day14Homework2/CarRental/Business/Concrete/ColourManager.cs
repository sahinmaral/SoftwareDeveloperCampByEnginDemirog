using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation;

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
            if (DateTime.Now.Hour == ConstantValues.ServerMaintenanceHour)
            {
                return new ErrorDataResult<List<Colour>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Colour>>(_colourDal.GetAll());
        }

        public IDataResult<Colour> Get(Expression<Func<Colour, bool>> filter)
        {
            return new SuccessDataResult<Colour>(_colourDal.Get(filter), Messages.SuccessfullyRetrieved);
        }

        public IDataResult<Colour> GetById(int colourId)
        {
            return new SuccessDataResult<Colour>(_colourDal.Get(x => x.ColourId == colourId));
        }
        [SecuredOperation("colour.add,admin")]
        [ValidationAspect(typeof(ColourValidator))]
        public IResult Insert(Colour colour)
        {
            _colourDal.Add(colour);
            return new SuccessResult(Messages.SuccessfullyAdded);
        }
        [SecuredOperation("colour.update,admin")]

        public IResult Update(Colour colour)
        {
            _colourDal.Update(colour);
            return new SuccessResult(Messages.SuccessfullyUpdated);
        }
        [SecuredOperation("colour.delete,admin")]

        public IResult Delete(Colour colour)
        {
            _colourDal.Delete(colour);
            return new SuccessResult(Messages.SuccessfullyDeleted);
        }
    }
}