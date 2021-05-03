using Entities.Concrete;

using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IColourService
    {
        public List<Colour> GetAll();
        public List<Colour> GetByColourId(int id);
        public void Add(Colour colour);
    }
}
