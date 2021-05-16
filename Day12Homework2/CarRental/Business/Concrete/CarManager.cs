using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private ICarDal _carDal;

        public CarManager(ICarDal cardal)
        {
            _carDal = cardal;
        }

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 0)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarListRetrieved);
        }

        public IDataResult<Car> Get(Expression<Func<Car, bool>> filter)
        {
            return new SuccessDataResult<Car>(_carDal.Get(filter), Messages.CarRetrieved);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            if (DateTime.Now.Hour == 0)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), Messages.CarDetailListRetrieved);
        }

        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(x => x.CarId == carId));
        }

        public IResult Insert(Car car)
        {
            var context = new ValidationContext<Car>(car);
            CarValidator carValidator = new CarValidator();
            var validationResult = carValidator.Validate(context);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }


            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }
    }
}