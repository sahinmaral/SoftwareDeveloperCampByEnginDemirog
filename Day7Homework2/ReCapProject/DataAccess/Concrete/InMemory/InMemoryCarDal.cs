using DataAccess.Abstract;

using Entities.Concrete;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>()
            {
                new Car{CarId=1,BrandId=1,ColorId=1,ModelYear=2015,DailyPrice=150000,Description="Toyota"},
                new Car{CarId=2,BrandId=2,ColorId=2,ModelYear=2016,DailyPrice=150000,Description="Mercedes Benz"},
                new Car{CarId=3,BrandId=3,ColorId=2,ModelYear=2016,DailyPrice=150000,Description="Chevrolet"},
                new Car{CarId=4,BrandId=4,ColorId=3,ModelYear=2018,DailyPrice=150000,Description="Renault"},
                new Car{CarId=5,BrandId=5,ColorId=3,ModelYear=2017,DailyPrice=150000,Description="Fiat"}
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }
        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.CarId = car.CarId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int CarId)
        {
            return _cars.Where(c => c.CarId == CarId).ToList();
        }

        
    }
}
