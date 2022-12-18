using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class UserGame:IEntity
    {
        public int UserGameId { get; set; }
        public int UserId { get; set; }
        public int GameId { get; set; }
    }
}
