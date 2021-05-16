using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Concrete;
using Core.DataAccess.EntityFramework;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : GenericBaseController<Rental,IRentalService>
    {
        private IRentalService _rentalService;
        public RentalsController(IRentalService serviceBase) : base(serviceBase)
        {
            _rentalService = serviceBase;
        }


    }
}
