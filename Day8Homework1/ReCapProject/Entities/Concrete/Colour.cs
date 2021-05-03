using Entities.Abstract;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    public class Colour:IEntity
    {
        public int ColourId { get; set; }
        public string ColourName { get; set; }
    }
}
