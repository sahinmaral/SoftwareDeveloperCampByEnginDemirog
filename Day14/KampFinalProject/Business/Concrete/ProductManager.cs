using Business.Abstract;
using Business.Constants;

using Core.Utilities.Results;

using DataAccess.Abstract;

using Entities.Concrete;
using Entities.DTOs;

using System;
using System.Collections.Generic;
using System.Linq;
using Business.BusinessAspects.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Business;


namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;
        private ICategoryService _categoryService;

        public ProductManager(IProductDal productDal, ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
        }

        public IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductListed);
        }
        [SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            var result = BusinessRules.Run(
                CheckIfProductCountOfCategoryOverload(product.CategoryId),
                CheckIfExistSameProductName(product.ProductName), CheckCategoryOverload());


            if (result != null)
            {
                return result;
            }

            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);

        }

        private IResult CheckCategoryOverload()
        {
            var result = _categoryService.GetAll().Data.Count();
            if (result >= 15)
            {
                return new ErrorResult(Messages.CategoryOverload);
            }

            return new SuccessResult();
        }

        private IResult CheckIfExistSameProductName(string productName)
        {
            var result = _productDal.GetAll(x => x.ProductName == productName).Any();
            if (!result)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.ProductNameAlreadyExists);
            
        }


        [ValidationAspect(typeof(ProductValidator))]
        public IResult Update(Product product)
        {


            throw new NotImplementedException();
        }

        private IResult CheckIfProductCountOfCategoryOverload(int categoryId)
        {
            int result = _productDal.GetAll().Count(x => x.CategoryId == categoryId);
            if (result + 1 >= 30)
            {
                return new ErrorResult(Messages.ProductCategoryOverload);
            }
            return new SuccessResult();
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(x => x.ProductId == productId));
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(
                _productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            if (DateTime.Now.Hour == 17)
            {
                return new ErrorDataResult<List<ProductDetailDto>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }
    }
}