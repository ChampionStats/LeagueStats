using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LeagueStats.Models
{
    public class Champion
    {
        [Key]
        public int ChampionID { get; set; }

        public int ID { get; set; }

        public string Title { get; set; }

        public string Key { get; set; }

        public string Name { get; set; }
    }
}
