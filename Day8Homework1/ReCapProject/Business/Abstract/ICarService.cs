using Entities.Concrete;
using Entities.DTOs;

using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        public List<Car> GetAll();
        public List<CarDetailDto> GetCarDetailDto();
        public List<Car> GetCarsByBrandId(int id);
        public List<Car> GetCarsByColourId(int id);
        public void Add(Car car);
    }
}
