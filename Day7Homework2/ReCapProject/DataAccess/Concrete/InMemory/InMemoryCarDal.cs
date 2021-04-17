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
        List<Brand> _brands;
        List<Color> _colors;
        public InMemoryCarDal()
        {
            _cars = new List<Car>()
            {
                new Car{CarId=1,BrandId=1,ColorId=1,ModelYear=2015,DailyPrice=150000,Description="Corolla"},
                new Car{CarId=2,BrandId=2,ColorId=2,ModelYear=2016,DailyPrice=150000,Description="A200"},
                new Car{CarId=3,BrandId=3,ColorId=2,ModelYear=2016,DailyPrice=150000,Description="Camaro"},
                new Car{CarId=4,BrandId=4,ColorId=3,ModelYear=2018,DailyPrice=150000,Description="Fluence"},
                new Car{CarId=5,BrandId=5,ColorId=3,ModelYear=2017,DailyPrice=150000,Description="Linea"}
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

            _colors = new List<Color>()
            {
                new Color{ColorId=1 , ColorName="Black" },
                new Color{ColorId=2 , ColorName="White" },
                new Color{ColorId=3 , ColorName="Red" },
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

        public List<CarDetails> GetAll()
        {
            var result = from ca in _cars
                         join br in _brands on ca.BrandId equals br.BrandId
                         join co in _colors on ca.ColorId equals co.ColorId
                         select new CarDetails
                         {
                             CarId = ca.CarId,
                             BrandName = br.BrandName,
                             ColorName = co.ColorName,
                             DailyPrice = ca.DailyPrice,
                             ModelYear = ca.ModelYear,
                             Description = ca.Description
                         };
            
            return result.ToList();
        }

        public List<CarDetails> GetById(int CarId)
        {
            var result = from ca in _cars
                         join br in _brands on ca.BrandId equals br.BrandId
                         join co in _colors on ca.ColorId equals co.ColorId
                         select new CarDetails
                         {
                             CarId = ca.CarId,
                             BrandName = br.BrandName,
                             ColorName = co.ColorName,
                             DailyPrice = ca.DailyPrice,
                             ModelYear = ca.ModelYear,
                             Description = ca.Description
                         };
            return result.Where(c => c.CarId == CarId).ToList();
        }
            


    }
}
