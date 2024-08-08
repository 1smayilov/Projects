using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Delete(Rental rental)
        {
            if (rental.ReturnDate is null)
            {
                return new ErrorResult(Messages.TheCarWasNotReturned);
            }
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.ProductDeleted);

        }

        public IDataResult<List<Rental>> GetAll()
        {
            if (DateTime.Now.Hour == 11)
            {
                return new ErrorDataResult<List<Rental>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.ProductsListed);
        }

        public IDataResult<Rental> GetbyID(int RentalId)
        {
            if (DateTime.Now.Hour == 17)
            {
                return new ErrorDataResult<Rental>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<Rental>(_rentalDal.Get(u => u.RentalId == RentalId), Messages.ProductsListed);
        }

        public IResult Insert(Rental rental)
        {
            if (rental.ReturnDate is null)
            {
                return new ErrorResult(Messages.TheCarWasNotReturned);
            }
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Update(Rental rental)
        {
            if (rental.ReturnDate is null)
            {
                return new ErrorResult(Messages.TheCarWasNotReturned);
            }
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.ProductUpdated);
        }
      }
    }
