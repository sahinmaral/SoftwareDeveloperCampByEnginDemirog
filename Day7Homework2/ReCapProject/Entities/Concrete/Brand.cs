using Entities.Abstract;

using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    class Brand:IEntity
    {
        public int BrandId { get; set; }
        public short BrandName { get; set; }
    }
}
