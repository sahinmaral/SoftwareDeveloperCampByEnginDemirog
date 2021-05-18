using Core.Entities;

using System;

namespace Entities.Concrete
{
    public class CarImages : IEntity
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public string ImagePath { get; set; }
        public DateTime Date { get; set; }

        public CarImages()
        {
            Date = DateTime.Now;
        }
    }
}
