using Business.Abstract;
using Business.Constants;
using Business.ValidateRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        [ValidationAspect(typeof(ColorValidator))]
        public IResult Delete(Color color)
        {
            if(color.ColorName.Length > 2)
            {
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            _colorDal.Delete(color);
            return new SuccessResult(Messages.ProductDeleted);
        }

        public IDataResult<List<Color>> GetAll()
        {
            if (DateTime.Now.Hour == 17)
            {
                return new ErrorDataResult<List<Color>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(),Messages.ProductsListed);
        }

        public IDataResult<Color> GetbyID(int colorId)
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<Color>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<Color>(_colorDal.Get(co=>co.ColorId == colorId),Messages.ProductsListed);
        }

        [ValidationAspect(typeof(ColorValidator))]
        public IResult Insert(Color color)
        {
            if(color.ColorName.Length > 2)
            {
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            _colorDal.Add(color);
            return new SuccessResult(Messages.ProductAdded);
        }

        [ValidationAspect(typeof(ColorValidator))]
        public IResult Update(Color color)
        {
            if (color.ColorName.Length < 2)
            {
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            _colorDal.Update(color);
            return new SuccessResult(Messages.ProductUpdated);
        }
    }
}
