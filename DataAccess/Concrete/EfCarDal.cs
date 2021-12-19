using Core.DataAccess;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete
{
    public class EfCarDal : EfEntityRepositoryBase<Car, Context>, ICarDal
    {
        public List<CarDetailDto> GetCarDetailBrandDto(int id)
        {
            using (Context db = new Context())
            {
                var result = from car in db.Cars
                             join brand in db.Brands on car.BrandId equals brand.Id
                             join color in db.Colors on car.ColorId equals color.Id
                             where car.BrandId == id
                             select new CarDetailDto
                             {
                                 Id = car.Id,
                                 BrandName = brand.BrandName,
                                 CarName = car.Description,
                                 ColorName = color.ColorName,
                                 DailyPrice = car.DailyPrice,
                                 ModelYear = car.ModelYear,
                                 Description = car.Description
                             };
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarDetailColorDto(int id)
        {
            using (Context db = new Context())
            {
                var result = from car in db.Cars
                             join brand in db.Brands on car.BrandId equals brand.Id
                             join color in db.Colors on car.ColorId equals color.Id
                             where car.ColorId==id
                             select new CarDetailDto
                             {
                                 Id = car.Id,
                                 BrandName = brand.BrandName,
                                 CarName = car.Description,
                                 ColorName = color.ColorName,
                                 DailyPrice = car.DailyPrice,
                                 ModelYear = car.ModelYear,
                                 Description = car.Description
                             };
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarDetailDto(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            //using (Context db= new Context())
            //{
            //    var result = from car in db.Cars
            //                 join brand in db.Brands on car.BrandId equals brand.Id
            //                 join color in db.Colors on car.ColorId equals color.Id
            //                 select new CarDetailDto
            //                 {
            //                     Id=car.Id,
            //                     BrandName = brand.BrandName,
            //                     CarName = car.Description,
            //                     ColorName = color.ColorName,
            //                     DailyPrice = car.DailyPrice,
            //                     ModelYear=car.ModelYear,
            //                     Description=car.Description
            //                 };
            //    return result.ToList();
            //}
            using (Context db = new Context())
            {
                var result = from car in db.Cars
                             join brand in db.Brands on car.BrandId equals brand.Id
                             join color in db.Colors on car.ColorId equals color.Id
                             select new CarDetailDto
                             {
                                 Id = car.Id,
                                 BrandName = brand.BrandName,
                                 CarName = car.Description,
                                 ColorName = color.ColorName,
                                 DailyPrice = car.DailyPrice,
                                 ModelYear = car.ModelYear,
                                 Description = car.Description,
                                 CarImage = ((from ci in db.CarImages
                                              where (car.Id == ci.CarId)
                                              select new CarImage
                                              {
                                                  CarId = ci.CarId,
                                                  Id = ci.Id,
                                                  Date = ci.Date,
                                                  ImagePath = ci.ImagePath
                                              }).ToList()).Count == 0
                                            ? new List<CarImage> { new CarImage { Id = -1, CarId = car.Id, Date = DateTime.Now, ImagePath = "/images/default.jpg" } }
                                            : (from ci in db.CarImages
                                               where (car.Id == ci.CarId)
                                               select new CarImage
                                               {
                                                   Id = ci.Id,
                                                   CarId = car.Id,
                                                   Date = ci.Date,
                                                   ImagePath = ci.ImagePath
                                               }).ToList()
                             };
                return filter == null
                    ? result.ToList()
                    : result.Where(filter).ToList();
            }
        }
    }
}
