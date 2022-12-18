using Core.Utilities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IGameService
    {
        IResult Add(Game game);
        IDataResult<List<Game>> GetAll();
        IDataResult<Game> GetById(int id);
        IResult Update(Game game);

    }
}
