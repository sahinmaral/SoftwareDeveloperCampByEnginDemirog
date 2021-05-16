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
    public class CarsController : GenericBaseController<Car,ICarService>
    {
        private ICarService _carService;
        public CarsController(ICarService serviceBase) : base(serviceBase)
        {
            _carService = serviceBase;
        }

        [HttpGet("getcardetails")]
        public IActionResult GetCarDetails()
        {
            return GetResponseByResult(_carService.GetCarDetails());
        }

    }
}
