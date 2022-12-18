using Core.Utilities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserOperationClaimsService
    {
        IResult GiveAuthToUser(string userName, string operationClaim);
        IResult TakeAuthFromUser(string user, string operationClaim);
    }
}
