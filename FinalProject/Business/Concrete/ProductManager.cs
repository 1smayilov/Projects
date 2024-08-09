using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductsListed);
            // Data _productDal.GetAll() - dur
            // Console.WriteLine(result.Data.ProductName); // "Laptop"
        }


        public IDataResult<List<Product>> GetAllByCategory(int categoryId)
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == categoryId), Messages.ProductsListed);
        }


        public IDataResult<List<Product>> GetUnitPrice(decimal min, decimal max)
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max), Messages.ProductsListed);
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<ProductDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails(), Messages.ProductsListed);
        }


        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded); 
        }

        public IDataResult<Product> GetById(int productId)
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<Product>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<Product>(_productDal.Get(p=>p.ProductId == productId),Messages.ProductsListed);
        }
    }
}
