using Core.Utilities.Results;

using Entities.Concrete;
using Entities.DTOs;

using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICarService : IServiceBase<Car>
    {
        IDataResult<List<CarDetailDto>> GetCarDetails();
    }
}
