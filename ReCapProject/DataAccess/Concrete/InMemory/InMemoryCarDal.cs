using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car { Id = 1,BrandId = 1,ColorId=1,DailyPrice=250,ModelYear=2018,Description="Yeni ban 0" },
                new Car { Id = 2,BrandId = 1,ColorId=2,DailyPrice=300,ModelYear=2020,Description="Yeni ban 1" },
                new Car { Id = 3,BrandId = 2,ColorId=3,DailyPrice=500,ModelYear=2024,Description="Yeni ban 2" },
                new Car { Id = 4,BrandId = 1,ColorId=1,DailyPrice=200,ModelYear=2016,Description="Yeni ban 3" },
                new Car { Id = 5,BrandId = 3,ColorId=1,DailyPrice=600,ModelYear=2024,Description="Yeni ban 4" },
                new Car { Id = 6,BrandId = 3,ColorId=2,DailyPrice=650,ModelYear=2024,Description="Yeni ban 5" }
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car); 
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(_c=>_c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int Id)
        {
            return _cars.Where(_c=>_c.Id==Id).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(_c => _c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
