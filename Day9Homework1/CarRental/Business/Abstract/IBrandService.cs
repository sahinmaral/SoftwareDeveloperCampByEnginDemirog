using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IBrandService
    {
        List<Brand> GetAll();
        Brand GetById(int brandId);
        void Insert(Brand colour);
        void Update(Brand colour);
        void Delete(Brand colour);
    }
}
