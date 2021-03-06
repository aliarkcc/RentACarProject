using Business.Abstract;
using Business.Constants;
using Business.ValidationRules;
using Core.Aspect;
using Core.Aspect.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult();
        }

        public IDataResult<Rental> Get(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == id),Messages.RentalListed);
        }

        public IDataResult<List<Rental>> GetAll()
        {
                return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalsListed);
            
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetailDtos()
        {
            var values = _rentalDal.GetRentalDetailDtos();
            return new SuccessDataResult<List<RentalDetailDto>>(values, Messages.RentalDetailDtosListed);
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }
    }
}
