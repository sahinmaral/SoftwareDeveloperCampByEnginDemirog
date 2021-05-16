using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Concrete;
using Core.Entities;
using Core.Utilities.Results;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace WebAPI.Controllers
{
    
    [ApiController]
    public class GenericBaseController<TEntity, TService> : ControllerBase
                where TEntity : IEntity 
                where TService : IServiceBase<TEntity>
    {
        protected TService _tService;

        public GenericBaseController(TService tService)
        {
            _tService = tService;
        }

        [HttpGet("getall")]
        public virtual IActionResult GetAll()
        {
            return GetResponseByResult(_tService.GetAll());
        }

        [HttpGet("getbyid")]
        public virtual IActionResult GetById(int id)
        {
            return GetResponseByResult(_tService.GetById(id));
        }

        [HttpPost("add")]
        public virtual IActionResult Add(TEntity entity)
        {
            return GetResponseByResult(_tService.Insert(entity));
        }
        [HttpPost("update")]
        public virtual IActionResult Update(TEntity entity)
        {
            return GetResponseByResult(_tService.Update(entity));
        }
        [HttpPost("delete")]
        public virtual IActionResult Delete(TEntity entity)
        {
            return GetResponseByResult(_tService.Delete(entity));
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

