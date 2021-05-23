using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Concrete;
using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        public UsersController(IUserService serviceBase) 
        {
            _userService = serviceBase;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            return GetResponseByResult(_userService.GetAll());
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            return GetResponseByResult(_userService.GetById(id));
        }

        [HttpPost("add")]
        public IActionResult Add(User user)
        {
            return GetResponseByResult(_userService.Insert(user));
        }
        [HttpPost("update")]
        public IActionResult Update(User user)
        {
            return GetResponseByResult(_userService.Update(user));
        }
        [HttpPost("delete")]
        public IActionResult Delete(User user)
        {
            return GetResponseByResult(_userService.Delete(user));
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
