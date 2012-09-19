using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LootAlert
{
    class LegendaryFinder
    {
        private List<int> IgnoreList;
        private int LastLevelArea;

        public LegendaryFinder()
        {
            IgnoreList = new List<int>();
        }

        public Sound FindLegendary()
        {
            if (d3.Initialized == false)
                return Sound.None;
            Actor p = d3.player;
            if (p == null || p.acd == null)
                return Sound.None;

            if (LastLevelArea != d3.GetLevelArea())
            {
                IgnoreList.Clear();
                LastLevelArea = d3.GetLevelArea();
            }

            foreach (Actor a in d3.Actors)
            {
                if (a == null || a.acd == null)
                    continue;
                if (a.acd.acdType != ACDType.Item)
                    continue;
                if (IgnoreList.Contains(a.actor_guid + a.snoid))
                    continue;

                int Qlvl = a.GetInt(Attrib.Item_Quality_Level);
                if (Qlvl >= 9 && Settings.PlayOnLegendary)
                {
                    IgnoreList.Add(a.actor_guid + a.snoid);
                    return Sound.Legendary;
                }


                else if (Qlvl >= 6 && Qlvl <= 8 && Settings.PlayOnRare)
                {
                    bool isMax62 = IsMax62(a.acd);
                    if ((isMax62 && a.acd.ItemLevel >= Settings.Min62s) || 
                        (!isMax62 && a.acd.ItemLevel >= Settings.Min63s))
                    {
                        IgnoreList.Add(a.actor_guid + a.snoid);
                        return Sound.Rare;
                    }
                }

                else if (a.name.Contains("CraftingPlan") && Settings.PlayOnCrafting)
                {
                    IgnoreList.Add(a.actor_guid + a.snoid);
                    return Sound.Crafting;
                }

                else if (Settings.PlayOnMagic && Qlvl >= 3 && Qlvl <= 5 && a.acd.ItemLevel >= Settings.MinMagic)
                {
                    IgnoreList.Add(a.actor_guid + a.snoid);
                    return Sound.Magic;
                }
            }
            return Sound.None;
        }

        private bool IsMax62(ACD item)
        {
            if (item.IsItem)
            {
                if (item.name.Contains("Ring") ||
                    item.name.Contains("Amulet") ||
                    item.name.Contains("Quiver") ||
                    item.name.Contains("Mojo") ||
                    item.name.Contains("orb_"))
                    return true;
                if (item.ItemName.Contains("SpiritStone") ||
                    item.ItemName.Contains("BarbBelt") ||
                    item.ItemName.Contains("Cloak") ||
                    item.ItemName.Contains("WizardHat") ||
                    item.ItemName.Contains("VoodooMask"))
                    return true;
            }
            return false;
        }
    }
}
