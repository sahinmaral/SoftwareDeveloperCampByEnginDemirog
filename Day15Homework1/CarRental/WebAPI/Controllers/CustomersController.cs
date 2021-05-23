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
    public class CustomersController : ControllerBase
    {
        private ICustomerService _customerService;
        public CustomersController(ICustomerService serviceBase) 
        {
            _customerService = serviceBase;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            return GetResponseByResult(_customerService.GetAll());
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            return GetResponseByResult(_customerService.GetById(id));
        }

        [HttpPost("add")]
        public IActionResult Add(Customer customer)
        {
            return GetResponseByResult(_customerService.Insert(customer));
        }
        [HttpPost("update")]
        public IActionResult Update(Customer customer)
        {
            return GetResponseByResult(_customerService.Update(customer));
        }
        [HttpPost("delete")]
        public IActionResult Delete(Customer customer)
        {
            return GetResponseByResult(_customerService.Delete(customer));
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
