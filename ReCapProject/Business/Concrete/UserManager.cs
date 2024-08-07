﻿using Business.Abstract;
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
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Delete(User user)
        {
            if(user.Firstname.Length < 2)
            {
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            _userDal.Delete(user);
            return new SuccessResult(Messages.ProductDeleted);
            
        }

        public IDataResult<List<User>> GetAll()
        {
            if(DateTime.Now.Hour == 17)
            {
                return new ErrorDataResult<List<User>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<User>>(_userDal.GetAll(),Messages.ProductsListed);
        }

        public IDataResult<User> GetbyID(int userId)
        {
            if (DateTime.Now.Hour == 17)
            {
                return new ErrorDataResult<User>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<User>(_userDal.Get(u=>u.UserId == userId),Messages.ProductsListed);
            }

            public IResult Insert(User user)
        {
            if(user.Lastname.Length < 2)
            {
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            _userDal.Add(user);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Update(User user)
        {
            if (user.Lastname.Length < 2)
            {
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            _userDal.Update(user);
            return new SuccessResult(Messages.ProductUpdated);
        }
    }
}
