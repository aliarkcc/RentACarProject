using Business.Abstract;
using Business.Constants;
using Core.Utilities.Helper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult Add(IFormFile file, CarImage carImage)
        {
            carImage.Date = DateTime.Now;
            var carImageResult = FileHelper.Upload(file);
            if (carImageResult.Success)
            {
                var count = _carImageDal.GetAll(x=>x.CarId==carImage.CarId).Count;
                if (count>5)
                {
                    return new ErrorResult(Messages.CarImageAddedInvalid);
                }
                carImage.ImagePath = carImageResult.Message;
                _carImageDal.Add(carImage);
                return new SuccessResult(Messages.CarImageAdded);
            }
            else
            {
                return new ErrorResult(Messages.CarImageInvalid);
            }
        }

        public IResult Delete(CarImage carImage)
        {
            var image = _carImageDal.Get(x => x.Id == carImage.Id);
            if (image != null)
            {
                FileHelper.Delete(image.ImagePath);
                _carImageDal.Delete(carImage);
                return new SuccessResult(Messages.CarImageDeleted);
            }
            else
            {
                return new ErrorResult(Messages.CarImageDeletedInvalid);
            }
        }

        public IDataResult<CarImage> Get(int carImageId)
        {
            var result = _carImageDal.Get(x => x.Id == carImageId);
            return new SuccessDataResult<CarImage>(result, Messages.CarImageListed);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.CarImagesListed);
        }

        public IDataResult<CarImage> GetImagesByCarId(int carId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(x => x.CarId == carId));
        }

        public IResult Update(IFormFile formFile, CarImage carImage)
        {
            var imageResult = _carImageDal.Get(x => x.Id == carImage.Id);
            if (imageResult != null)
            {
                var updatedfile = FileHelper.Update(formFile, imageResult.ImagePath);
                _carImageDal.Update(carImage);
                return new SuccessResult(Messages.CarImageUpdated);
            }
            else
            {
                return new ErrorResult(Messages.CarImageUpdatedInvalid);
            }
        }
    }
}
