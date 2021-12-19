﻿using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> GetById(int id);
        IDataResult<List<Car>> GetCarsByBrandId(int id);
        IDataResult<List<Car>> GetCarsByColorId(int id);
        IDataResult<List<CarDetailDto>> GetCarDetailDtos(Expression<Func<CarDetailDto, bool>> filter = null);
        IDataResult<List<CarDetailDto>> GetCarDetailBrandDtos(int id);
        IDataResult<List<CarDetailDto>> GetCarDetailColorsDtos(int id);
        IResult Add(Car car);
        IResult Delete(Car car);
        IResult Update(Car car);
        

    }
}
