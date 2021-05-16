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
    public class CustomersController : GenericBaseController<Customer,ICustomerService>
    {
        private ICustomerService _customerService;
        public CustomersController(ICustomerService serviceBase) : base(serviceBase)
        {
            _customerService = serviceBase;
        }


    }
}
