using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Game:IEntity
    {
        public int GameId { get; set; }
        public string GameName { get; set; }
        public int CampaignId { get; set; }
    }
}
