using Core.Utilities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserGameService
    {
        IResult Buy(User user, Game game);
        IResult Remand(User user, Game game);
    }
}
