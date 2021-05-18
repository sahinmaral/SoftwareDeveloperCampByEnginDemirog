using Business.Abstract;

using Core.Utilities.Results;

using Entities.Concrete;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        private ICarImagesService _carImagesService;

        public CarImagesController(ICarImagesService serviceBase)
        {
            _carImagesService = serviceBase;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            return GetResponseByResult(_carImagesService.GetAll());
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            return GetResponseByResult(_carImagesService.GetById(id));
        }
        private IResult CheckIfFileUploaded(IFormFile formFile)
        {
            if (formFile == null || formFile.Length < 1)
            {
                return new ErrorResult("Please select at least one image to upload!");
            }

            return new SuccessResult();
        }

        [HttpPost("add")]
        public IActionResult Add(CarImages carImages)
        {
            return GetResponseByResult(_carImagesService.Insert(carImages));
        }


        [HttpPost("update")]
        public IActionResult Update(CarImages carImages)
        {
            return GetResponseByResult(_carImagesService.Update(carImages));
        }
        [HttpPost("delete")]
        public IActionResult Delete(CarImages carImages)
        {
            return GetResponseByResult(_carImagesService.Delete(carImages));
        }

        public IActionResult GetResponseByResult(IResult result)
        {
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


    }
}
