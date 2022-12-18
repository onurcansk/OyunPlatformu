using Business.Abstract;
using Business.Constants;
using Core.Utilities.Abstract;
using Core.Utilities.Conrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
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

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult("Kullanıcı eklendi.");
        }

        public IDataResult<User> GetByMail(string email)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Mail == email));
        }

        public IDataResult<User> GetByUserName(string userName)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.UserName == userName));
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult("Kullanıcı güncellendi.");
        }
    }
}
