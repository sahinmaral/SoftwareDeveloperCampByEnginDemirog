using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Core.Aspects.Autofac.Caching;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        [CacheAspect(10)]
        public IDataResult<List<Rental>> GetAll()
        {
            if (DateTime.Now.Hour == ConstantValues.ServerMaintenanceHour)
            {
                return new ErrorDataResult<List<Rental>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        [CacheAspect(10)]
        public IDataResult<Rental> Get(Expression<Func<Rental, bool>> filter)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(filter), Messages.SuccessfullyRetrieved);
        }

        [CacheAspect(10)]
        public IDataResult<Rental> GetById(int rentalId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(x => x.RentalId == rentalId));
        }
        [SecuredOperation("rental.add,admin")]
        [CacheRemoveAspect("IRentalService.Get,IRentalService.GetAll,IRentalService.GetById")]
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Insert(Rental rental)
        {
            var result = _rentalDal.GetAll().SingleOrDefault(x => x.CarId == rental.CarId);
            if (result == null)
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.SuccessfullyRetrieved);
            }

            return new ErrorResult(Messages.RentalCarNotAvailable);
        }
        [SecuredOperation("rental.update,admin")]
        [CacheRemoveAspect("IRentalService.Get,IRentalService.GetAll,IRentalService.GetById")]
        public IResult Update(Rental rental)
        {
            var result = _rentalDal.GetAll(x => x.CarId == rental.CarId).SingleOrDefault();
            if (result == null)
            {
                return new ErrorResult(Messages.NoSelectedCarsOnRented);
            }

            rental.RentalId = result.RentalId;
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.SuccessfullyUpdated);
        }
        [SecuredOperation("rental.delete,admin")]
        [CacheRemoveAspect("IRentalService.Get,IRentalService.GetAll,IRentalService.GetById")]
        public IResult Delete(Rental rental)
        {
            var result = _rentalDal.GetAll(x => x.CarId == rental.CarId).SingleOrDefault();
            if (result == null)
            {
                return new ErrorResult(Messages.NoSelectedCarsOnRented);
            }

            rental.RentalId = result.RentalId;
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.SuccessfullyDeleted);
        }
    }
}