using Business.Abstract;
using Business.Constants;
using Business.ValidateRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult Delete(CarImage carImage)
        {
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.ProductDeleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            if(DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<List<CarImage>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(),Messages.ProductsListed);
        }

        public IDataResult<CarImage> GetById(int carImageId)
        {
            if (DateTime.Now.Hour == 17)
            {
                return new ErrorDataResult<CarImage>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<CarImage>(_carImageDal.Get(ci => ci.CarImageId == carImageId),Messages.ProductsListed);
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int carId)
        {

            var result = (_carImageDal.GetAll(ci => ci.CarId == carId));
            if(result.Count == 0)
            {
                result.Add(new CarImage { CarId = carId, CarImageDate = DateTime.Now, ImagePath = "default.jpg" });
            }
            return new SuccessDataResult<List<CarImage>>(result);
        }

        //[ValidationAspect(typeof(CarImageValidator))]
        public IResult Insert(IFormFile file ,CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageLimitExceeded(carImage.CarImageId));

            if(result != null)
            {
                return result;
            }

            carImage.ImagePath = FileHelper.SaveImage(file);
            carImage.CarImageDate = DateTime.Now;

            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Update(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageLimitExceeded(carImage.CarId));

            if(result != null)
            {
                return result;
            }

            carImage.ImagePath = FileHelper.SaveImage(file);
            carImage.CarImageDate = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.ProductUpdated);
        }

        private IResult CheckIfCarImageLimitExceeded(int carId)
        {
            var result = _carImageDal.GetAll(ci => ci.CarId == carId).Count;
            if(result >= 5)
            {
                return new ErrorResult(Messages.FalsePictureCount);
            }
            return new SuccessResult();
        }

        
    }
}
