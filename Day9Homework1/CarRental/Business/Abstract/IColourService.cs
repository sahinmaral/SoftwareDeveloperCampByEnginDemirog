using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IColourService
    {
        List<Colour> GetAll();
        Colour GetById(int colourId);
        void Insert(Colour colour);
        void Update(Colour colour);
        void Delete(Colour colour);
    }
}
