using Core.Utilities.Abstract;
using Core.Utilities.Conrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IOperationClaimsService
    {
        IResult AddNewClaim(OperationClaim claim);
        IResult RemoveClaimByClaimName(OperationClaim claim);
        IResult RemoveClaimById(int id);    
        IDataResult<List<OperationClaim>> GetAllClaims();
    }
}
