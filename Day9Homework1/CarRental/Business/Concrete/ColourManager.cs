using System;
using System.Collections.Generic;
using System.Text;

using Business.Abstract;

using DataAccess.Abstract;

using Entities.Concrete;

namespace Business.Concrete
{
    public class ColourManager : IColourService
    {
        private IColourDal _colourDal;

        public ColourManager(IColourDal colourDal)
        {
            _colourDal = colourDal;
        }


        public List<Colour> GetAll()
        {
            return _colourDal.GetAll();
        }

        public Colour GetById(int colourId)
        {
            return _colourDal.Get(x => x.ColourId == colourId);
        }

        public void Insert(Colour colour)
        {
            _colourDal.Add(colour);
        }

        public void Update(Colour colour)
        {
            _colourDal.Update(colour);
        }

        public void Delete(Colour colour)
        {
            _colourDal.Delete(colour);
        }
    }
}
