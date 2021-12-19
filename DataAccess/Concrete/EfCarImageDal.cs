using Core.DataAccess;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
namespace DataAccess.Concrete
{
    public class EfCarImageDal : EfEntityRepositoryBase<CarImage, Context>, ICarImageDal
    {
    }
}
