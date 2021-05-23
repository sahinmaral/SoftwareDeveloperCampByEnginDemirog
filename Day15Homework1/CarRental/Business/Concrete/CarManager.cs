using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.Aspects.Autofac.Caching;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private ICarDal _carDal;

        public CarManager(ICarDal cardal)
        {
            _carDal = cardal;
        }

        [CacheAspect(10)]
        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == ConstantValues.ServerMaintenanceHour)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.SuccessfullyRetrieved);
        }

        [CacheAspect(10)]
        public IDataResult<Car> Get(Expression<Func<Car, bool>> filter)
        {
            return new SuccessDataResult<Car>(_carDal.Get(filter), Messages.SuccessfullyRetrieved);
        }

        [CacheAspect(10)]
        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            if (DateTime.Now.Hour == ConstantValues.ServerMaintenanceHour)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), Messages.SuccessfullyRetrieved);
        }
        [CacheAspect(10)]
        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(x => x.CarId == carId));
        }
        [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get,ICarService.GetAll,ICarService.GetById,ICarService.GetCarDetails")]
        public IResult Insert(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Messages.SuccessfullyAdded);
        }
        [SecuredOperation("car.update,admin")]
        [CacheRemoveAspect("ICarService.Get,ICarService.GetAll,ICarService.GetById,ICarService.GetCarDetails")]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.SuccessfullyUpdated);
        }
        [SecuredOperation("car.delete,admin")]
        [CacheRemoveAspect("ICarService.Get,ICarService.GetAll,ICarService.GetById,ICarService.GetCarDetails")]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.SuccessfullyDeleted);
        }
    }
}