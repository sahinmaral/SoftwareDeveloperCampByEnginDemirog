using System;
using System.Security.Cryptography.X509Certificates;
using Business.Abstract;
using Core.Utilities.Helpers;
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
        private static string _currentDirectory = Environment.CurrentDirectory + "\\wwwroot";
        private static string _folderName = "\\Images\\System\\a.png";
        private string _defaultPath = _currentDirectory + _folderName;
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
                return new ErrorResult("You didn't upload at least one image.The image will be default.");
            }

            return new SuccessResult();
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm(Name = "Image")] IFormFile file, [FromForm] CarImages carImages)
        {
            var result=CheckIfFileUploaded(file);
            if (!result.Success)
            {
                return GetResponseByResult(result);

            }
            return GetResponseByResult(_carImagesService.Insert(file, carImages));
        }

        [HttpPost("update")]
        public IActionResult Update([FromForm(Name = "Image")] IFormFile file, [FromForm] CarImages carImages)
        {
            var entity = _carImagesService.GetById(carImages.Id);
            return GetResponseByResult(_carImagesService.Update(file, entity.Data));
        }
        [HttpPost("delete")]
        public IActionResult Delete([FromForm]int id)
        {
            var entity = _carImagesService.GetById(id);
            return GetResponseByResult(_carImagesService.Delete(entity.Data));
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
