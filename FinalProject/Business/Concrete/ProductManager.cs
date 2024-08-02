using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete

    // Sən _productDal vastəsilə product daldakı metodlara ulaşa bilirsən, onlardan istifadə edəcəksən
{
    // Bura iş kodlarıdır, istədiyi cürə metod yaza bilər
    public class ProductManager : IProductService
    {
        IProductDal _productDal; // Bağımlılığı minimaze edirəm

        // Bağımlılığımı konstraktırla göstərirəm
        public ProductManager(IProductDal productDal) 
        {
            // Mən Product manager olaraq veri erişim katmanına bağımlıyam

            // Mənə birdənə IProductDal referansı ver
            _productDal = productDal;
        }

        public List<Product> GetAll()
        {
            // İş kodları yazılıb bura ...  
            // Yetkisi varmı? (Hamısını listələməyə)
             return _productDal.GetAll();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _productDal.GetAll(p=>p.CategoryId == categoryId);
        }


        public List<Product> GetUnitPrice(decimal min, decimal max)
        {
            return _productDal.GetAll(p=>p.UnitPrice >= min && p.UnitPrice <= max);
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            return _productDal.GetProductDetails();
        }

    }
}
