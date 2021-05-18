using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;

using Core.Aspects.Autofac.Validation;
using Core.Business;
using Core.Utilities.Results;

using DataAccess.Abstract;

using Entities.Concrete;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class CarImagesManager : ICarImagesService
    {
        private ICarImagesDal _carImagesDal;

        public CarImagesManager(ICarImagesDal carImagesDal)
        {
            _carImagesDal = carImagesDal;
        }

        public IDataResult<List<CarImages>> GetAll()
        {
            if (DateTime.Now.Hour == 0)
            {
                return new ErrorDataResult<List<CarImages>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<CarImages>>(_carImagesDal.GetAll());
        }

        public IDataResult<CarImages> Get(Expression<Func<CarImages, bool>> filter)
        {
            return new SuccessDataResult<CarImages>(_carImagesDal.Get(filter), Messages.SuccessfullyRetrieved);
        }

        public IDataResult<CarImages> GetById(int carImageId)
        {
            return new SuccessDataResult<CarImages>(_carImagesDal.Get(x => x.Id == carImageId));
        }

        [ValidationAspect(typeof(CarImagesValidator))]
        public IResult Insert(CarImages carImages)
        {

            _carImagesDal.Add(carImages);
            return new SuccessResult(Messages.SuccessfullyAdded);
        }

        private IResult GetCarImagesLimitExceeded(int carId)
        {
            var result = _carImagesDal.GetAll(x => x.CarId == carId).GroupBy(x => x.CarId).Count();
            if (result >= 5)
            {
                return new ErrorResult(Messages.CarImagesLimitExceeded);
            }

            return new SuccessResult();
        }

        public string TakeCarImagePathIfItsNotEntered(CarImages carImages)
        {
            var path = carImages.ImagePath;

            if (path == null)
            {
                path = _carImagesDal.Get(x => x.Id == carImages.Id).ImagePath;
                carImages.ImagePath = path;
            }

            return carImages.ImagePath;
        }

        [ValidationAspect(typeof(CarImagesValidator))]
        public IResult Update(CarImages carImages)
        {

            _carImagesDal.Update(carImages);
            return new SuccessResult(Messages.SuccessfullyUpdated);
        }

        public IResult IsCarExisted(int id)
        {
            var result = _carImagesDal.GetAll(x => x.Id == id);
            if (result == null)
            {
                return new ErrorResult();
            }

            return new SuccessResult();
        }



        [ValidationAspect(typeof(CarImagesValidator))]
        public IResult Delete(CarImages carImages)
        {
            var result = BusinessRules.Run(IsCarExisted(carImages.Id));

            if (result != null)
            {
                _carImagesDal.Delete(carImages);
                return new SuccessResult(Messages.SuccessfullyDeleted);
            }

            return new ErrorResult(Messages.CarNotExisted);



        }
    }
}