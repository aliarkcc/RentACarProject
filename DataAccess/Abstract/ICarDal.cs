using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface ICarDal:IEntityRepository<Car>
    {
        List<CarDetailDto> GetCarDetailDto(Expression<Func<CarDetailDto, bool>> filter = null);
        List<CarDetailDto> GetCarDetailBrandDto(int id);
        List<CarDetailDto> GetCarDetailColorDto(int id);

    }
}
