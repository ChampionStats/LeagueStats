using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeagueStats.Models
{
    public class ChampionInfo
    {
        public int ChampionInfoID { get; set; }

        public int ChampionAppID { get; set; } // Links to 'ID' field on champion

        public int Difficulty { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Magic { get; set; }
    }
}
