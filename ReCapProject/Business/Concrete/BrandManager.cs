using Business.Abstract;
using Business.Constants;
using Business.ValidateRules.FluentValidation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }


        public IDataResult<List<Brand>> GetAll()    
        {
            if(DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<List<Brand>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), Messages.ProductsListed);

        }

        public IDataResult<Brand> GetbyID(int brandId)
        {
            if(DateTime.Now.Hour == 17)
            {
                return new ErrorDataResult<Brand>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<Brand>(_brandDal.Get(b=>b.BrandId == brandId),Messages.ProductsListed);
        }

        public IResult Insert(Brand brand)
        {
            var context = new ValidationContext<Brand>(brand);
            BrandValidator validations = new BrandValidator();
            var result = validations.Validate(context);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }

            _brandDal.Add(brand);
           return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Update(Brand brand)
        {
            if(brand.BrandName.Length < 2)
            {
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            _brandDal.Update(brand);
            return new SuccessResult(Messages.ProductUpdated);
        }
        public IResult Delete(Brand brand)
        {
            if (brand.BrandName.Length < 2)
            {
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.ProductDeleted);
        }
    }
}
