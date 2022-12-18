using Business.Abstract;
using Business.BusinessAspects.Autofac;
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
    public class UserGameManager : IUserGameService
    {
        IUserGameDal _userGameDal;
        IGameService _gameService;
        ICampaignService _campaignService;
        public UserGameManager(IGameService gameService, ICampaignService campaignService,IUserGameDal userGameDal)
        {
            _gameService = gameService;
            _campaignService = campaignService;
            _userGameDal = userGameDal;
        }
        [SecuredOperation("Admin,User")]
        public IResult Buy(User user, Game game)
        {
            _userGameDal.Add(new UserGame() { GameId=game.GameId,UserId=user.Id});
            return new SuccessResult("Satın alma işlemi başarılı.");
        }
        [SecuredOperation("Admin,User")]
        public IResult Remand(User user, Game game)
        {
            var result = _userGameDal.Get(ug => ug.UserId == user.Id && ug.GameId == game.GameId);
            _userGameDal.Delete(result);
            return new SuccessResult("Oyun iade edildi.");
            
        }
    }
}
