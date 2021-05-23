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
    public class BrandsController : ControllerBase
    {
        private IBrandService _brandService;
        public BrandsController(IBrandService serviceBase) 
        {
            _brandService = serviceBase;
        }

        [HttpGet("getall")]
        public  IActionResult GetAll()
        {
            return GetResponseByResult(_brandService.GetAll());
        }

        [HttpGet("getbyid")]
        public  IActionResult GetById(int id)
        {
            return GetResponseByResult(_brandService.GetById(id));
        }

        [HttpPost("add")]
        public  IActionResult Add(Brand brand)
        {
            return GetResponseByResult(_brandService.Insert(brand));
        }
        [HttpPost("update")]
        public  IActionResult Update(Brand brand)
        {
            return GetResponseByResult(_brandService.Update(brand));
        }
        [HttpPost("delete")]
        public  IActionResult Delete(Brand brand)
        {
            return GetResponseByResult(_brandService.Delete(brand));
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
