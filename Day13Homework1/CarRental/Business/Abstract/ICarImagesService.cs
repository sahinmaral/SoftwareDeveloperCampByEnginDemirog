﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.Utilities.Results;

using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface ICarImagesService 
    {
        IDataResult<List<CarImages>> GetAll();
        IDataResult<CarImages> Get(Expression<Func<CarImages, bool>> filter);
        IDataResult<CarImages> GetById(int entityId);
        IResult Insert(CarImages entity);
        IResult Update(CarImages entity);
        IResult Delete(CarImages entity);
    }
}
