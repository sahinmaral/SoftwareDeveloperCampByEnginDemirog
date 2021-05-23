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
using System.Linq.Expressions;
using Core.Aspects.Autofac.Caching;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        private IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        [CacheAspect(10)]
        public IDataResult<List<Brand>> GetAll()
        {
            if (DateTime.Now.Hour == ConstantValues.ServerMaintenanceHour)
            {
                return new ErrorDataResult<List<Brand>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll());
        }
        [CacheAspect(10)]
        public IDataResult<Brand> Get(Expression<Func<Brand, bool>> filter)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(filter), Messages.SuccessfullyRetrieved);
        }
        [CacheAspect(10)]
        public IDataResult<Brand> GetById(int brandId)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(x => x.BrandId == brandId));
        }
        [SecuredOperation("brand.add,admin")]
        [CacheRemoveAspect("IBrandService.Get,IBrandService.GetAll,IBrandService.GetById")]
        [ValidationAspect(typeof(BrandValidator))]
        public IResult Insert(Brand brand)
        {
            _brandDal.Add(brand);
            return new SuccessResult(Messages.SuccessfullyAdded);
        }
        [CacheRemoveAspect("IBrandService.Get,IBrandService.GetAll,IBrandService.GetById")]
        [SecuredOperation("brand.update,admin")]
        [CacheRemoveAspect("IBrandService.Get,IBrandService.GetAll,IBrandService.GetById")]
        public IResult Update(Brand brand)
        {
            _brandDal.Update(brand);
            return new SuccessResult(Messages.SuccessfullyUpdated);
        }
        [CacheRemoveAspect("IBrandService.Get,IBrandService.GetAll,IBrandService.GetById")]
        [SecuredOperation("brand.delete,admin")]
        [CacheRemoveAspect("IBrandService.Get,IBrandService.GetAll,IBrandService.GetById")]
        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.SuccessfullyDeleted);
        }
    }
}