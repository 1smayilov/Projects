using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryDal : IProductDal
    {
        List<Car> _cars;

        public InMemoryDal()
        {
            _cars = new List<Car>()
            {
                new Car{Id = 1, BrandId = 1, ColorId = 1, DailyPrice = 500, Description = "Esl Zovq", ModelYear = 2024},
                new Car{Id = 2, BrandId = 1, ColorId = 3, DailyPrice = 150, Description = "Tam istediyiniz", ModelYear = 2019},
                new Car{Id = 3, BrandId = 2, ColorId = 12, DailyPrice = 100, Description = "Ne bilim", ModelYear = 1983},
                new Car{Id = 4, BrandId = 3, ColorId = 7, DailyPrice = 400, Description = "Her neyse", ModelYear = 2023},
                new Car{Id = 5, BrandId = 2, ColorId = 6, DailyPrice = 50, Description = "Fikirlesme", ModelYear = 2015},
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }


        public void Delete(Car car)
        {
            Car DeleteToCar = _cars.SingleOrDefault(c=>c.Id ==  car.Id);
            _cars.Remove(DeleteToCar);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public Car GetById(int Id)
        {
            return _cars.SingleOrDefault(c => c.Id == Id);
            
        }

        

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
        }
    }
}
