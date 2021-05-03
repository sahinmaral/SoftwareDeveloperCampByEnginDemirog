using System;
using System.Collections.Generic;
using System.Text;

using Business.Abstract;

using DataAccess.Abstract;

using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CarManager:ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            if (car.Description.Length > 2 && car.DailyPrice > 0)
                _carDal.Add(car);

        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }


        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(p => p.BrandId == id);
        }

        public List<Car> GetCarsByColourId(int id)
        {
            return _carDal.GetAll(p => p.ColourId == id);
        }

        public List<CarDetailDto> GetCarDetailDto()
        {
            return _carDal.GetCarDetailDtos();
        }



    }
}
