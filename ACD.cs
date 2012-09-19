using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LootAlert
{
    public class ACD
    {
        public const int size = 0x2D0;

        //Standard ACD Data
        public int offset;
        public int acdguid { get { return d3.ReadInt(offset); } }
        public string name { get { return d3.ReadString(offset + 0x4, 128); } }
        public ACDType acdType { get { return (ACDType)d3.ReadInt(offset + 0xB0); } }
        public int gbid { get { return d3.ReadInt(offset + 0xB4); } }

        public int fagid { get { return d3.ReadInt(offset + 0x120); } }

        //Item Data
        public GameBalanceItem gbItem;
        public bool IsItem { get { return acdType == ACDType.Item; } }
        public int ItemLevel { get { return gbItem.itemLevel; } }
        public string ItemName { get { return gbItem.name; } }

        public ACD(int ofs)
        {
            offset = ofs;
            if (IsItem)
                GameBalance.LinkItem(this);
        }

        public override string ToString()
        {
            return name;
        }

        public int GetInt(Attrib attrib)
        {
            return GetInt((uint)attrib, 0);
        }

        public float GetFloat(Attrib attrib)
        {
            return GetFloat((uint)attrib, 0);
        }

        public int GetInt(uint id, uint mask = 0xFFFFF000)
        {
            return d3.ReadInt(d3.GetAttribFromFag(d3.GetFastAttribGroup(fagid), (uint)id | mask));
        }

        public float GetFloat(uint id, uint mask = 0xFFFFF000)
        {
            return d3.ReadFloat(d3.GetAttribFromFag(d3.GetFastAttribGroup(fagid), (uint)id | mask));
        }
    }

    public enum ACDType : int
    {
        Item = 2,
        Player = 7
    }
}
