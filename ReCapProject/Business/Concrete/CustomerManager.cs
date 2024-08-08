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
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult Delete(Customer customer)
        {
            if (customer.CompanyName.Length < 2)
            {
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            _customerDal.Delete(customer);
            return new SuccessResult(Messages.ProductDeleted);

        }

        public IDataResult<List<Customer>> GetAll()
        {
            if (DateTime.Now.Hour == 17)
            {
                return new ErrorDataResult<List<Customer>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), Messages.ProductsListed);
        }

        public IDataResult<Customer> GetbyID(int customerId)
        {
            if (DateTime.Now.Hour == 17)
            {
                return new ErrorDataResult<Customer>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<Customer>(_customerDal.Get(u => u.CustomerId == customerId), Messages.ProductsListed);
        }

        public IResult Insert(Customer customer)
        {
            if (customer.CompanyName.Length < 2)
            {
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            _customerDal.Add(customer);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Update(Customer customer)
        {
            if (customer.CompanyName.Length < 2)
            {
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            _customerDal.Update(customer);
            return new SuccessResult(Messages.ProductUpdated);
        }
    }
}
