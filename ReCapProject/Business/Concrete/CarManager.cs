﻿using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
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

        public void Add(Car car)
        {
            if(car.Description.Length < 2)
            {
                throw new Exception("Avtomobilin adi en az 2 herfden ibaret olmalidir");
            }
            if(car.DailyPrice <= 0)
            {
                throw new Exception("Avtomobilin gunluk icaresi 0-dan boyuk olmalidir");
            }
            _carDal.Add(car);
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(c=>c.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _carDal.GetAll(c => c.ColorId == id);

        }
    }
}
