using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeagueStats.Models
{
    public class ItemTags
    {
        public int ItemTagsID { get; set; }
        public int ItemID { get; set; }
        public string Tag { get; set; }

        public Item Item { get; set; }

    }
}
