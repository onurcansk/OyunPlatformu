using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Abstract;
using Core.Utilities.Conrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class GameManager : IGameService
    {
        IGameDal _gameDal;
        public GameManager(IGameDal GameDal)
        {
            _gameDal = GameDal;
        }


        [SecuredOperation("Game.Add,Admin")]
        [ValidationAspect(typeof(GameValidator), Priority = 1)]
        [CacheRemoveAspect("IGameService.Get")]
        public IResult Add(Game game)
        {
            _gameDal.Add(game);
            return new SuccessResult();
        }


        [CacheAspect(duration: 20)]
        [SecuredOperation("Game.GetAll,Admin")]
        public IDataResult<List<Game>> GetAll()
        {
            return new SuccessDataResult<List<Game>>(_gameDal.GetAll());
        }

        [CacheAspect(duration:5)]
        [SecuredOperation("Game.GetAll,Admin")]
        public IDataResult<Game> GetById(int id)
        {
            return new SuccessDataResult<Game>(_gameDal.Get(g => g.GameId == id));
        }
        [SecuredOperation("Game.Add,Admin")]
        [CacheRemoveAspect("IGameService.Get")]
        public IResult Update(Game game)
        {
            _gameDal.Update(game);
            return new SuccessResult();
        }
    }
}
