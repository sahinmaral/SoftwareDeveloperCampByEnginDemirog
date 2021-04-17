using Entities.Abstract;

using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class CarDetails:IEntity
    {
        public int CarId { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public short ModelYear { get; set; }
        public int DailyPrice { get; set; }
        public string Description { get; set; }
    }
}
