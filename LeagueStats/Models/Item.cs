using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LeagueStats.Models
{
    public class Item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ItemID { get; set; }
        public string Description { get; set; }
        public string Plaintext { get; set; }
        public int Depth { get; set; }
        public string Name { get; set; }
        public string SanitizedDescription { get; set; }

        /*
        public ItemGold ItemGold { get; set; }
        public ItemImage ItemImage { get; set; }
        public ItemStats ItemStats { get; set; }

        public ICollection<ItemInto> ItemInto { get; set; }
        public ICollection<ItemMaps> ItemMaps { get; set; }
        public ICollection<ItemTags> ItemTags { get; set; }


    */


    }
}
