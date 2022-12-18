using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Utilities.Abstract;
using Core.Utilities.Conrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserOperationClaimsManager : IUserOperationClaimsService
    {
       
        IOperationClaimsService _operationClaimsService;
        public UserOperationClaimsManager(IOperationClaimsService operationClaimsService)
        {

            _operationClaimsService = operationClaimsService;
        }
        [SecuredOperation("Admin,Modaretor")]
        public IResult GiveAuthToUser(string userName, string operationClaim)
        {
            throw new NotImplementedException();
        }
        [SecuredOperation("Admin,Modaretor")]
        public IResult TakeAuthFromUser(string user, string operationClaim)
        {
            throw new NotImplementedException();
        }
     

        private IDataResult<int> CheckIfClaimExists(string claimName)
        {
            var result = _operationClaimsService.GetAllClaims();
            var claim = result.Result.SingleOrDefault<OperationClaim>(op => op.Name == claimName);
            if (claim!=null)
            {
                return new SuccessDataResult<int>(claim.Id);
            }
            return new SuccessDataResult<int>(Messages.ClaimNotFound);
        }
    }
}
