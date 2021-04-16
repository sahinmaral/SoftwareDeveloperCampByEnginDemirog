using Entities.Concrete;

using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal
    {
        //GetById, GetAll, Add, Update, Delete
        public List<Car> GetById(int CarId);
        public List<Car> GetAll();
        public void Add(Car car);
        public void Update(Car car);
        public void Delete(Car car);
    }
}
