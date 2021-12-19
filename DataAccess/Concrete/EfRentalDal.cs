using Core.DataAccess;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, Context>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetailDtos()
        {
            using (Context db= new Context())
            {
                var result = from rental in db.Rentals
                             join car in db.Cars on rental.CarId equals car.Id
                             join brand in db.Brands on car.BrandId equals brand.Id
                             join customer in db.Customers on rental.CustomerId equals customer.UserId
                             select new RentalDetailDto
                             {
                                 Id = rental.Id,
                                 BrandName = brand.BrandName,
                                 CustomerName = customer.CompanyName,
                                 RentDate = rental.RentDate,
                                 ReturnDate = rental.ReturnDate
                             };
                return result.ToList();
            }
        }
    }
}