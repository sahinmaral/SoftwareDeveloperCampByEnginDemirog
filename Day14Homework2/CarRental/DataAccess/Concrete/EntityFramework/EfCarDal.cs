using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Core.DataAccess.EntityFramework;

using DataAccess.Abstract;

using Entities.Concrete;
using Entities.DTOs;

using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarRentalContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from car in context.Cars
                    join co in context.Colours on car.ColourId equals co.ColourId
                    join br in context.Brands on car.BrandId equals br.BrandId
                    select new CarDetailDto()
                    {
                        CarId = car.CarId,
                        BrandName = br.BrandName,
                        ColourName = co.ColourName,
                        CarName = car.CarName,
                        DailyPrice = car.DailyPrice
                    };

                return result.ToList();
            }
        }
    }
}