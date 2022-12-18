using Core.Utilities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICampaignService
    {
        IResult AddNewCampaign(Campaign campaign);
        IResult AddCampaignToGame(Game game, Campaign campaign);
        IResult RemoveCampaignFromGame(Game game);
        IResult RemoveCampaign(Campaign campaign);
    }
}
