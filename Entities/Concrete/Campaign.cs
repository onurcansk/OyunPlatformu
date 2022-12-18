using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Campaign:IEntity
    {
        public int CampaignId { get; set; }
        public double Discount { get; set; }
        public int CampaignDuration { get; set; }
        public DateTime StartsDate { get; set; }
        public DateTime? EndsDate { get; set; }
    }
}
