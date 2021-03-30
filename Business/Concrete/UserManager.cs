using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Message.UserAdded);
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Message.UserAdded);
        }

        public IDataResult<List<User>> GetAll()
        {
            var data = _userDal.GetAll();
            return new SuccessDataResult<List<User>>(data, Message.UsersListed);
        }

        public IDataResult<User> GetById(int id)
        {
            var data = _userDal.Get(u => u.Id == id);
            return new SuccessDataResult<User>(data, Message.UsersListed);
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Message.UserAdded);
        }
        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }

        public IDataResult<User> GetByMail(string email)
        {
            User user = _userDal.Get(u => u.Email.ToLower() == email.ToLower());

            if (user == null)
            {
                return new ErrorDataResult<User>(Messages.MessageNotListed);
            }
            else
            {
                return new SuccessDataResult<User>(user, Messages.MessageListed);
            }
        }
        //[SecuredOperation("admin,user.updateinfos")]
        [ValidationAspect(typeof(UserValidator))]
        [CacheRemoveAspect("IUserService.Get")]
        public IResult UpdateSpecificInfos(User user)
        {
            User userInfos = GetById(user.Id).Data;

            userInfos.FirstName = user.FirstName;
            userInfos.LastName = user.LastName;
            userInfos.Email = user.Email;

            _userDal.Update(userInfos);

            return new SuccessResult(Messages.UserUpdated);
        }
    }
}
