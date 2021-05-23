using Business.Abstract;
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
    public class CustomerManager : ICustomerService
    {
        private ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        [CacheAspect(10)]
        public IDataResult<List<Customer>> GetAll()
        {
            if (DateTime.Now.Hour == ConstantValues.ServerMaintenanceHour)
            {
                return new ErrorDataResult<List<Customer>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll());
        }

        [CacheAspect(10)]
        public IDataResult<Customer> Get(Expression<Func<Customer, bool>> filter)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(filter), Messages.SuccessfullyRetrieved);
        }
        [CacheAspect(10)]
        public IDataResult<Customer> GetById(int customerId)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(x => x.Id == customerId));
        }

        [CacheRemoveAspect("ICustomerService.Get,ICustomerService.GetAll,ICustomerService.GetById")]
        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Insert(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessResult(Messages.SuccessfullyAdded);
        }

        [ValidationAspect(typeof(CustomerValidator))]
        [CacheRemoveAspect("ICustomerService.Get,ICustomerService.GetAll,ICustomerService.GetById")]
        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult(Messages.SuccessfullyUpdated);
        }

        [CacheRemoveAspect("ICustomerService.Get,ICustomerService.GetAll,ICustomerService.GetById")]
        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult(Messages.SuccessfullyDeleted);
        }
    }
}