﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeagueStats.Models
{
    public class ItemStats
    {
        public int ItemStatsID { get; set; }
        public int ItemID { get; set; }

        public double PercentCritDamageMod { get; set; }
        public double PercentSpellBlockMod { get; set; }
        public double PercentHPRegenMod { get; set; }
        public double PercentMovementSpeedMod { get; set; }
        public double FlatSpellBlockMod { get; set; }
        public double FlatCritDamageMod { get; set; }
        public double FlatEnergyPoolMod { get; set; }
        public double PercentLifeStealMod { get; set; }
        public double FlatMPPoolMod { get; set; }
        public double FlatMovementSpeedMod { get; set; }
        public double PercentAttackSpeedMod { get; set; }
        public double FlatBlockMod { get; set; }
        public double PercentBlockMod { get; set; }
        public double FlatEnergyRegenMod { get; set; }
        public double PercentSpellVampMod { get; set; }
        public double FlatMPRegenMod { get; set; }
        public double PercentDodgeMod { get; set; }
        public double FlatAttackSpeedMod { get; set; }
        public double FlatArmorMod { get; set; }
        public double FlatHPRegenMod { get; set; }
        public double PercentMagicDamageMod { get; set; }
        public double PercentMPPoolMod { get; set; }
        public double FlatMagicDamageMod { get; set; }
        public double PercentMPRegenMod { get; set; }
        public double PercentPhysicalDamageMod { get; set; }
        public double FlatPhysicalDamageMod { get; set; }
        public double PercentHPPoolMod { get; set; }
        public double PercentArmorMod { get; set; }
        public double PercentCritChanceMod { get; set; }
        public double PercentEXPBonus { get; set; }
        public double FlatHPPoolMod { get; set; }
        public double FlatCritChanceMod { get; set; }
        public double FlatEXPBonus { get; set; }

        public Item Item { get; set; }


    }
}
