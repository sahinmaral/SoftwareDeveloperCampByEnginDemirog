using Entities.Concrete;

using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        public List<CarDetails> GetAll();
        public void Add(Car car);
    }
}
