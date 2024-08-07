﻿using Business.Abstract;
using Business.Constants;
using Business.ValidateRules.FluentValidation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;   
        }

        public IResult Delete(Car car)
        {
            if(car.CarName.Length < 2)
            {
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            _carDal.Delete(car);
            return new SuccessResult(Messages.ProductDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            if(DateTime.Now.Hour == 17)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.ProductsListed);
        }

        public IDataResult<Car> GetbyID(int carId)
        {
            if(DateTime.Now.Hour == 17)
            {
                return new ErrorDataResult<Car>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<Car>(_carDal.Get(c => c.CarID == carId),Messages.ProductsListed);
        }


        public IDataResult<List<Car>> GetCarsBrandId(int brandId)
        {
            if (DateTime.Now.Hour == 17)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId),Messages.ProductsListed);
        }

        public IDataResult<List<Car>> GetCarsColorId(int colorId)
        {
            if (DateTime.Now.Hour == 17)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c=>c.ColorId == colorId),Messages.ProductsListed);
        }

        public IResult Insert(Car car)
        {
            var context = new ValidationContext<Car>(car);
            CarValidator validationRules = new CarValidator();
            var result = validationRules.Validate(context);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
            _carDal.Add(car);
            return new SuccessResult(Messages.ProductAdded);
        }

       

        public IResult Update(Car car)
        {
            if (car.CarName.Length < 2)
            {
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            _carDal.Update(car);
            return new SuccessResult(Messages.ProductUpdated);
        }
        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(),Messages.ProductsListed);
        }

        
    }
}
