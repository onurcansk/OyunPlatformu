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
    public class CampaignManager : ICampaignService
    {
        IGameService _gameService;
        ICampaignDal _campaignDal;
        public CampaignManager(ICampaignDal campaignDal,IGameService gameService)
        {
            _gameService = gameService;
            _campaignDal = campaignDal;
        }
        [SecuredOperation("Admin")]
        public IResult AddCampaignToGame(Game game, Campaign campaign)
        {
            game.CampaignId=campaign.CampaignId;
            var result = _gameService.Update(game);
            if (result.Success)
            {
                return new SuccessResult("Oyuna kampanya uygulandı.");
            }
            return new ErrorResult(result.Message);
        }
        [SecuredOperation("Admin")]
        public IResult AddNewCampaign(Campaign campaign)
        {
            _campaignDal.Add(campaign);
            return new SuccessResult("Kampanya oluşturuldu");
        }
        [SecuredOperation("Admin")]
        public IResult RemoveCampaign(Campaign campaign)
        {
            _campaignDal.Delete(campaign);
            return new SuccessResult("Kampanya silindi");
        }
        [SecuredOperation("Admin")]
        public IResult RemoveCampaignFromGame(Game game)
        {
            game.CampaignId = default;
            _gameService.Update(game);
            return new SuccessResult("Oyundan kampanya kaldırıldı.");
        }

        
    }
}
