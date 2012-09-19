using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace LootAlert
{
    class GameBalance
    {
        public const int GameBalance_Items_Armor = 19750;
        public const int GameBalance_Items_Other = 19753;
        public const int GameBalance_Items_Weapons = 19754;

        #region lists
        private static Dictionary<int, GameBalanceItem>  Items;
        public static Dictionary<int, GameBalanceItem> gbItems
        {
            get
            {
                if (Items == null) //Only need to do this once
                {
                    Items = new Dictionary<int, GameBalanceItem>();
                    int armorOfs = SNO.GetOffsetFromSNOID(19750, SNO.GameBalanceSNO);
                    int otherOfs = SNO.GetOffsetFromSNOID(19753, SNO.GameBalanceSNO);
                    int wepOfs = SNO.GetOffsetFromSNOID(19754, SNO.GameBalanceSNO);

                    //ARMOR FILE
                    int ofs = armorOfs + 0x218;
                    while (d3.ReadInt(ofs) == 0)
                        ofs += 0x4;

                    int size = d3.ReadInt(ofs + 0x4);
                    ofs = armorOfs + d3.ReadInt(ofs);
                    for (int i = 0; i < size; i += 0x5F0)
                    {
                        GameBalanceItem g = new GameBalanceItem(ofs + i);
                        Items.Add(g.gbid, g);
                    }

                    //WEAPON FILE
                    ofs = wepOfs + 0x218;
                    while (d3.ReadInt(ofs) == 0)
                        ofs += 0x4;

                    size = d3.ReadInt(ofs + 0x4);
                    ofs = wepOfs + d3.ReadInt(ofs);
                    for (int i = 0; i < size; i += 0x5F0)
                    {
                        GameBalanceItem g = new GameBalanceItem(ofs + i);
                        Items.Add(g.gbid, g);
                    }

                    //OTHER FILE
                    ofs = otherOfs + 0x218;
                    while (d3.ReadInt(ofs) == 0)
                        ofs += 0x4;

                    size = d3.ReadInt(ofs + 0x4);
                    ofs = otherOfs + d3.ReadInt(ofs);
                    for (int i = 0; i < size; i += 0x5F0)
                    {
                        GameBalanceItem g = new GameBalanceItem(ofs + i);
                        Items.Add(g.gbid, g);
                    }
                }
                return Items;
            }
        }
        #endregion

        #region funcs
        public static void LinkItems(List<ACD> items)
        {
            foreach (ACD i in items)
            {
                if(gbItems.ContainsKey(i.gbid))
                {
                    GameBalanceItem g = gbItems[i.gbid];
                    i.gbItem = g;
                }
            }
        }
        public static void LinkItem(ACD i)
        {
            if (gbItems.ContainsKey(i.gbid))
            {
                GameBalanceItem g = gbItems[i.gbid];
                i.gbItem = g;
            }
        }
        #endregion
    }

    public class GameBalanceItem
    {
        public const int size = 0x5F0;

        public int offset;
        public int gbid { get { return d3.ReadInt(offset); } }
        public string name { get { return d3.ReadString(offset + 0x4, 100); } }
        public int itemLevel { get { return d3.ReadInt(offset + 0x114); } }

        public GameBalanceItem(int ofs)
        {
            offset = ofs;
        }
    }
}
