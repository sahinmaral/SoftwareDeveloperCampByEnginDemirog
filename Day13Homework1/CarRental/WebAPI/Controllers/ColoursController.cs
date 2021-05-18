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
    public class ColoursController : ControllerBase
    {
        private IColourService _colourService;
        public ColoursController(IColourService serviceBase)
        {
            _colourService = serviceBase;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            return GetResponseByResult(_colourService.GetAll());
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            return GetResponseByResult(_colourService.GetById(id));
        }

        [HttpPost("add")]
        public IActionResult Add(Colour colour)
        {
            return GetResponseByResult(_colourService.Insert(colour));
        }
        [HttpPost("update")]
        public IActionResult Update(Colour colour)
        {
            return GetResponseByResult(_colourService.Update(colour));
        }
        [HttpPost("delete")]
        public IActionResult Delete(Colour colour)
        {
            return GetResponseByResult(_colourService.Delete(colour));
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
