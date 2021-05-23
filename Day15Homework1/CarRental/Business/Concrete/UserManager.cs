using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        [CacheAspect(10)]
        public IDataResult<List<User>> GetAll()
        {
            if (DateTime.Now.Hour == ConstantValues.ServerMaintenanceHour)
            {
                return new ErrorDataResult<List<User>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }
        [CacheAspect(10)]
        public IDataResult<User> Get(Expression<Func<User, bool>> filter)
        {
            return new SuccessDataResult<User>(_userDal.Get(filter), Messages.SuccessfullyRetrieved);
        }
        [CacheAspect(10)]
        public IDataResult<User> GetById(int userId)
        {
            return new SuccessDataResult<User>(_userDal.Get(x => x.Id == userId));
        }
        [CacheRemoveAspect("IUserService.GetAll,IUserService.Get,IUserService.GetById")]
        [ValidationAspect(typeof(UserValidator))]
        public IResult Insert(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.SuccessfullyAdded);
        }
        [CacheRemoveAspect("IUserService.GetAll,IUserService.Get,IUserService.GetById")]
        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.SuccessfullyUpdated);
        }
        [CacheRemoveAspect("IUserService.GetAll,IUserService.Get,IUserService.GetById")]
        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.SuccessfullyDeleted);
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }

        public IDataResult<User> GetByMail(string email)
        {
            var result = _userDal.Get(x => x.Email == email);
            if (result != null)
            {
                return new SuccessDataResult<User>(result);
            }
            return new ErrorDataResult<User>(Messages.UserNotFound);
        }
    }
}