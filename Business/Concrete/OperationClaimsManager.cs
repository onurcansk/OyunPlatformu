using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Abstract;
using Core.Utilities.Business;
using Core.Utilities.Conrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class OperationClaimsManager : IOperationClaimsService
    {
        IOperationClaimDal _operationClaim;
        public OperationClaimsManager(IOperationClaimDal operationClaim)
        {
            _operationClaim = operationClaim;
        }

        [ValidationAspect(typeof(OperationClaim))]
        [SecuredOperation("Admin,Modaretor")]
        public IResult AddNewClaim(OperationClaim claim)
        {
            IResult result = BusinessRules.Run(CheckIfClaimNameExists(claim.Name));
            if (result!=null)
            {
                return result;
            }
            _operationClaim.Add(claim);
            return new SuccessResult(Messages.ClaimAdded);
            

        }

        [SecuredOperation("Admin,Modaretor")]
        public IDataResult<List<OperationClaim>> GetAllClaims()
        {
            var result = _operationClaim.GetAll();
            return new SuccessDataResult<List<OperationClaim>>(result,Messages.ClaimsListed);
        }

        [SecuredOperation("Admin,Modaretor")]
        public IResult RemoveClaimByClaimName(OperationClaim claim)
        {
            IResult result = BusinessRules.Run(CheckIfClaimNameExists(claim.Name));
            if (result==null)
            {
                return new ErrorResult(Messages.ClaimNotFound);
            }
            _operationClaim.Delete(claim);
            return new SuccessResult(Messages.ClaimRemoved);
        }
        [SecuredOperation("Admin,Modaretor")]
        public IResult RemoveClaimById(int id)
        {
            var claim = _operationClaim.Get(claim => claim.Id ==id);
            if (claim == null)
            {
                return new ErrorResult(Messages.ClaimNotFound);
            }
            _operationClaim.Delete(claim);
            return new SuccessResult(Messages.ClaimRemoved);
        }

        private IResult CheckIfClaimNameExists(string claimName)
        {

            var result = _operationClaim.GetAll(p => p.Name == claimName).Any();
            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);
            }

            return new SuccessResult();
        }
    }
}
