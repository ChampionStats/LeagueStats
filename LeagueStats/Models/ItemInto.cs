using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeagueStats.Models
{
    public class ItemInto
    {
        public int ItemIntoID { get; set; }
        public int ItemID { get; set; }
        public int ItemIntoItemID { get; set; }

        public Item Item { get; set; }


    }
}
