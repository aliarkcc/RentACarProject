using Core.DataAccess;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete
{
    public class EfCarDal : EfEntityRepositoryBase<Car, Context>, ICarDal
    {
        public List<CarDetailDto> GetCarDetailDto()
        {
            using (Context db= new Context())
            {
                var result = from car in db.Cars
                             join brand in db.Brands on car.BrandId equals brand.Id
                             join color in db.Colors on car.ColorId equals color.Id
                             select new CarDetailDto
                             {
                                 BrandName = brand.BrandName,
                                 CarName = car.Description,
                                 ColorName = color.ColorName,
                                 DailyPrice = car.DailyPrice
                             };
                return result.ToList();
            }
        }
    }
}
