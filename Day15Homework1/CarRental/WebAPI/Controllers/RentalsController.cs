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
    public class RentalsController : ControllerBase
    {
        private IRentalService _rentalService;
        public RentalsController(IRentalService serviceBase) 
        {
            _rentalService = serviceBase;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            return GetResponseByResult(_rentalService.GetAll());
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            return GetResponseByResult(_rentalService.GetById(id));
        }

        [HttpPost("add")]
        public IActionResult Add(Rental rental)
        {
            return GetResponseByResult(_rentalService.Insert(rental));
        }
        [HttpPost("update")]
        public IActionResult Update(Rental rental)
        {
            return GetResponseByResult(_rentalService.Update(rental));
        }
        [HttpPost("delete")]
        public IActionResult Delete(Rental rental)
        {
            return GetResponseByResult(_rentalService.Delete(rental));
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
