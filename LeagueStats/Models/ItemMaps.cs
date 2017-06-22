using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeagueStats.Models
{
    public class ItemMaps
    {
        public int ItemMapsID { get; set; }
        public int ItemID { get; set; }
        public int MapID { get; set; }
        public bool Exists { get; set; }

        public Item Item { get; set; }
    }
}
