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
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using Business.BusinessAspects.Autofac;
using Core.Utilities.Helpers;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class CarImagesManager : ICarImagesService
    {
        
        private ICarImagesDal _carImagesDal;
        private IFileHelper _fileHelper;

        public CarImagesManager(ICarImagesDal carImagesDal, IFileHelper fileHelper)
        {
            _carImagesDal = carImagesDal;
            _fileHelper = fileHelper;
        }

        public IDataResult<List<CarImages>> GetAll()
        {
            if (DateTime.Now.Hour == ConstantValues.ServerMaintenanceHour)
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
        [SecuredOperation("carimages.add,admin")]


        [ValidationAspect(typeof(CarImagesValidator))]
        public IResult Insert(IFormFile file, CarImages carImages)
        {
            var result = BusinessRules.Run(GetCarImagesLimitExceeded(carImages.CarId));

            if (result != null)
            {
                return result;
            }
            SetDefaultCarImageOrNot(file, carImages);
            _carImagesDal.Add(carImages);
            return new SuccessResult(Messages.SuccessfullyAdded);
        }
        [SecuredOperation("carimages.update,admin")]

        private IResult GetCarImagesLimitExceeded(int carId)
        {
            var result = _carImagesDal.GetAll(x => x.CarId == carId).Count();
            if (result >= ConstantValues.CarImagesLimitCount)
            {
                return new ErrorResult(Messages.CarImagesLimitExceeded);
            }

            return new SuccessResult();
        }
        private void SetDefaultCarImageOrNot(IFormFile file, CarImages carImages)
        {
            if (file == null)
            {
                carImages.ImagePath = ConstantValues.DefaultCarImagePath;
            }
            else
            {
                var imageResult = _fileHelper.Upload(file);
                carImages.ImagePath = imageResult.Message;
            }
        }

        private void UpdateImage(IFormFile file, CarImages carImages)
        {
            var result = _carImagesDal.GetAll().Single(x => x.Id == carImages.Id).ImagePath;


            if (carImages.ImagePath == ConstantValues.DefaultCarImagePath && file != null)
            {
                var imageResult = _fileHelper.Upload(file);
                carImages.ImagePath = imageResult.Message;
            }
            else if (file == null && result== ConstantValues.DefaultCarImagePath)
            {
                carImages.ImagePath = ConstantValues.DefaultCarImagePath;
            }
            else if (file==null && result!= ConstantValues.DefaultCarImagePath)
            {
                FileHelper fileHelper = new FileHelper();
                fileHelper.Delete(result);
                carImages.ImagePath = ConstantValues.DefaultCarImagePath;
            }
            else
            {
                var imageResult = _fileHelper.Update(file, carImages.ImagePath);
                carImages.ImagePath = imageResult.Message;
            }
        }
        [SecuredOperation("carimages.update,admin")]

        [ValidationAspect(typeof(CarImagesValidator))]
        public IResult Update(IFormFile file, CarImages carImages)
        {
            UpdateImage(file, carImages);
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
        [SecuredOperation("carimages.delete,admin")]

        [ValidationAspect(typeof(CarImagesValidator))]
        public IResult Delete(CarImages carImages)
        {
            var result = BusinessRules.Run(IsCarExisted(carImages.Id));

            if (result != null)
            {
                return new ErrorResult(Messages.CarNotExisted);
            }

            _fileHelper.Delete(carImages.ImagePath);
            _carImagesDal.Delete(carImages);
            return new SuccessResult(Messages.SuccessfullyDeleted);



        }
    }
}