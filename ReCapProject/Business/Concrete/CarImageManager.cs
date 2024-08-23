using Business.Abstract;
using Business.Constants;
using Business.ValidateRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Helpers.FileHelper;
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
        private readonly ICarImageDal _carImageDal;
        private readonly IFileHelper _fileHelper;

        public CarImageManager(ICarImageDal carImageDal, IFileHelper fileHelper)
        {
            _carImageDal = carImageDal;
            _fileHelper = fileHelper;
        }

        public IResult Delete(CarImage carImage)
        {
            IResult result = BusinessRules.Run(ExistingCarImage(carImage.CarImageId));

            if (result != null)
            {
                return result;
            }

            _fileHelper.Delete(carImage.ImagePath); // Faylı sistemdən silirik.
            _carImageDal.Delete(carImage); // Database - dən silirik
            return new SuccessResult(Messages.ImageDeleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.ImagesListed);
        }

        public IDataResult<CarImage> GetById(int carImageId)
        {
            var result = _carImageDal.Get(c=>c.CarImageId == carImageId);
            if(result == null)
            {
                return new ErrorDataResult<CarImage>(result, Messages.ImageNotFound);
            }
            return new SuccessDataResult<CarImage>(result, Messages.ImagesListed);
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId);
            if (result.Count == 0)
            {
                return new SuccessDataResult<List<CarImage>>(new List<CarImage>
                {
                    new CarImage { ImagePath = "wwwroot/Images/default.jpg" }
                });
            }
            return new SuccessDataResult<List<CarImage>>(result, Messages.ImagesListed);
        }

        public IResult Insert(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(ImageCount(carImage.CarId));

            var fileName = _fileHelper.Upload(file, "wwwroot/Images");
            carImage.ImagePath = fileName;
            carImage.CarImageDate = DateTime.Now;

            _carImageDal.Add(carImage); // Database - ə əlavə edirik.
            return new SuccessResult(Messages.ImagesAdded);
        }

        public IResult Update(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(ExistingCarImage(carImage.CarImageId));

            if(result != null)
            {
                return result;
            }

             // Mövcud faylı silirik və yenisini yükləyirik
            var existingCarImage = _carImageDal.Get(c => c.CarImageId == carImage.CarImageId);
            var newFile = _fileHelper.Update(file, existingCarImage.ImagePath, "wwwroot/Images");
            carImage.ImagePath = newFile;
            carImage.CarImageDate = DateTime.Now;
            _carImageDal.Update(carImage); // Database-də yenilənir.
            return new SuccessResult(Messages.ImagesUpdated);
        }

        private IResult ExistingCarImage(int carImageId)
        {
            var existingCarImage = _carImageDal.Get(c => c.CarImageId == carImageId);
            if (existingCarImage == null)
            {
                return new ErrorResult(Messages.ImageNotFound);
            }
            return new SuccessResult();
        }

        private IResult ImageCount(int carId)
        {
           var result =  _carImageDal.GetAll(c => c.CarId == carId).Count;

            if(result > 5)
            {
                return new ErrorResult(Messages.FalseImageCount);
            }
            return new SuccessResult();
        }
    }
}
