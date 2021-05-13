using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Business.Abstract;
using Business.Constants;

using Core.Utilities.Results;

using DataAccess.Abstract;

using Entities.Concrete;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IDataResult<List<Rental>> GetAll()
        {

            if (DateTime.Now.Hour == 0)
            {
                return new ErrorDataResult<List<Rental>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<Rental> GetById(int rentalId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(x => x.RentalId == rentalId));
        }

        public IResult Insert(Rental rental)
        {
            if (rental.ReturnDate.Equals(new DateTime(0001, 01, 1)))
            {
                return new ErrorResult(Messages.ReturnDateCannotBeNull);
            }

            else if (rental.ReturnDate.Day - rental.RentDate.Day < 0)
            {
                return new ErrorResult(Messages.RentalDayLessThanZero);
            }

            var result = _rentalDal.GetAll().SingleOrDefault(x => x.CarId == rental.CarId);
            if (result == null)
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.RentalAdded);
            }
            else
            {
                if (result.ReturnDate != null)
                {
                    return new ErrorResult(Messages.RentalCarNotAvailable);
                }
                else
                {
                    _rentalDal.Add(rental);
                    return new SuccessResult(Messages.RentalAdded);
                }
            }


        }

        public IResult Update(Rental rental)
        {
            var result = _rentalDal.GetAll(x => x.CarId == rental.CarId).SingleOrDefault();
            if (result==null)
            {
                return new ErrorResult(Messages.NoSelectedCarsOnRented);
            }

            rental.RentalId = result.RentalId;
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }

        public IResult Delete(Rental rental)
        {
            var result = _rentalDal.GetAll(x => x.CarId == rental.CarId).SingleOrDefault();
            if (result == null)
            {
                return new ErrorResult(Messages.NoSelectedCarsOnRented);
            }

            rental.RentalId = result.RentalId;
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }
    }
}
