using DataAccess.Abstract;

using Entities.Concrete;
using Entities.DTOs;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        List<Brand> _brands;
        List<Colour> _colors;
        public InMemoryCarDal()
        {
            _cars = new List<Car>()
            {
                new Car{CarId=1,BrandId=1,ColourId=1,ModelYear=2015,DailyPrice=150000,Description="Corolla"},
                new Car{CarId=2,BrandId=2,ColourId=2,ModelYear=2016,DailyPrice=150000,Description="A200"},
                new Car{CarId=3,BrandId=3,ColourId=2,ModelYear=2016,DailyPrice=150000,Description="Camaro"},
                new Car{CarId=4,BrandId=4,ColourId=3,ModelYear=2018,DailyPrice=150000,Description="Fluence"},
                new Car{CarId=5,BrandId=5,ColourId=3,ModelYear=2017,DailyPrice=150000,Description="Linea"}
            };

            _brands = new List<Brand>()
            {
                new Brand{BrandId=1 , BrandName="Toyota" },
                new Brand{BrandId=2 , BrandName="Mercedes Benz" },
                new Brand{BrandId=3 , BrandName="Chevrolet" },
                new Brand{BrandId=4 , BrandName="Renault" },
                new Brand{BrandId=5 , BrandName="Fiat" },
                new Brand{BrandId=6 , BrandName="Audi" }
            };

            _colors = new List<Colour>()
            {
                new Colour{ColourId=1 , ColourName="Black" },
                new Colour{ColourId=2 , ColourName="White" },
                new Colour{ColourId=3 , ColourName="Red" },
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
            carToUpdate.ColourId = car.ColourId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }

        public List<Car> GetAll()
        {
            var result = from ca in _cars
                         join br in _brands on ca.BrandId equals br.BrandId
                         join co in _colors on ca.ColourId equals co.ColourId
                         select new Car
                         {
                             CarId = ca.CarId,
                             BrandId = br.BrandId,
                             ColourId = co.ColourId,
                             DailyPrice = ca.DailyPrice,
                             ModelYear = ca.ModelYear,
                             Description = ca.Description
                         };
            
            return result.ToList();
        }

        public List<Car> GetById(int CarId)
        {
            var result = from ca in _cars
                         join br in _brands on ca.BrandId equals br.BrandId
                         join co in _colors on ca.ColourId equals co.ColourId
                         select new Car
                         {
                             CarId = ca.CarId,
                             BrandId = br.BrandId,
                             ColourId = co.ColourId,
                             DailyPrice = ca.DailyPrice,
                             ModelYear = ca.ModelYear,
                             Description = ca.Description
                         };
            return result.Where(c => c.CarId == CarId).ToList();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetailDtos()
        {
            throw new NotImplementedException();
        }
    }
}
