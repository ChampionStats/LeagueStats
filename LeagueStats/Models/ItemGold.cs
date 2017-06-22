using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeagueStats.Models
{
    public class ItemGold
    {
        public int ItemGoldID { get; set; }
        public int ItemID { get; set; }
        public int Base { get; set; }
        public int Total { get; set; }
        public int Sell { get; set; }
        public bool Purchasable { get; set; }

        public Item Item { get; set; }
    }
}
