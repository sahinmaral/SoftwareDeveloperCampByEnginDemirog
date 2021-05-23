using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Concrete;
using Core.DataAccess.EntityFramework;
using Core.Utilities.Results;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private ICarService _carService;
        public CarsController(ICarService serviceBase)
        {
            _carService = serviceBase;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            return GetResponseByResult(_carService.GetAll());
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            return GetResponseByResult(_carService.GetById(id));
        }

        [HttpPost("add")]
        public IActionResult Add(Car car)
        {
            return GetResponseByResult(_carService.Insert(car));
        }
        [HttpPost("update")]
        public IActionResult Update(Car car)
        {
            return GetResponseByResult(_carService.Update(car));
        }
        [HttpPost("delete")]
        public IActionResult Delete(Car car)
        {
            return GetResponseByResult(_carService.Delete(car));
        }

        public IActionResult GetResponseByResult(IResult result)
        {
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

    }
}
