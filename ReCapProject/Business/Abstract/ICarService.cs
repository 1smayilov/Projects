using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetCarsBrandId(int brandId);
        List<Car> GetCarsColorId(int colorId);
        List<Car> GetAll(); 
        Car GetbyID(int carId);
        void Insert(Car car);
        void Update(Car car);
        void Delete(Car car);
        List<CarDetailDto> GetCarDetails();
    }
}
