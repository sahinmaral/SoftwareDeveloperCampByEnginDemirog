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
    public class BrandsController : GenericBaseController<Brand,IBrandService>
    {
        private IBrandService _brandService;
        public BrandsController(IBrandService serviceBase) : base(serviceBase)
        {
            _brandService = serviceBase;
        }


    }
}
