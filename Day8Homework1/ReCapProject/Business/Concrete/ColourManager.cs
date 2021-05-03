using Business.Abstract;

using DataAccess.Abstract;

using Entities.Concrete;

using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColourManager:IColourService
    {
        IColourDal _colourDal;
        public ColourManager(IColourDal colourDal)
        {
            _colourDal = colourDal;
        }

        public void Add(Colour colour)
        {
            _colourDal.Add(colour);
        }
        public List<Colour> GetAll()
        {
            return _colourDal.GetAll();
        }

        public List<Colour> GetByColourId(int id)
        {
            return _colourDal.GetAll(p => p.ColourId == id);
        }
    }
}
