using Entities.Concrete;

using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal
    {
        //GetById, GetAll, Add, Update, Delete
        public List<CarDetails> GetById(int CarId);
        public List<CarDetails> GetAll();
        public void Add(Car car);
        public void Update(Car car);
        public void Delete(Car car);
    }
}
