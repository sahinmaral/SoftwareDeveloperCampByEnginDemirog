using Entities.Concrete;

using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBrandService
    {
        public List<Brand> GetAll();
        public List<Brand> GetByBrandId(int id);
        public void Add(Brand brand);
    }
}
