using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidateRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
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
[PerformanceAspect(5)]
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        [SecuredOperation("getall,admin")]
        [CacheAspect]
        public IDataResult<List<Brand>> GetAll()
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<List<Brand>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), Messages.ProductsListed);

        }

        [SecuredOperation("getall,user")]
        [CacheAspect]
        public IDataResult<Brand> GetbyID(int brandId)
        {
            if(DateTime.Now.Hour == 17)
            {
                return new ErrorDataResult<Brand>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<Brand>(_brandDal.Get(b=>b.BrandId == brandId),Messages.ProductsListed);
        }


        //[SecuredOperation("admin,brand.add")]
        //[ValidationAspect(typeof(BrandValidator))]
        [CacheRemoveAspect("IBrandService.Get")]
        //[TransactionScopeAspect]
        public IResult Insert(Brand brand)
        {
            _brandDal.Add(brand);
           return new SuccessResult(Messages.ProductAdded);
        }




        [SecuredOperation("admin,brand.add")]
        [ValidationAspect(typeof(BrandValidator))]
        [CacheRemoveAspect("IBrandService.Get")]
        [TransactionScopeAspect]
        public IResult Update(Brand brand)
        {
            if(brand.BrandName.Length < 2)
            {
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            _brandDal.Update(brand);
            return new SuccessResult(Messages.ProductUpdated);
        }


        [SecuredOperation("admin,brand.add")]
        [ValidationAspect(typeof(BrandValidator))]
        [CacheRemoveAspect("IBrandService.Get")]
        [TransactionScopeAspect]
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
