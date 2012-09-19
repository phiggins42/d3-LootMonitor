using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LootAlert
{
    public class Actor
    {
        public const int size = 0x428;

        public int offset;
        private int aguidvalid;
        private int guidvalid;

        public int actor_guid { get { return d3.ReadInt(offset); } }
        public int acdguid { get { return d3.ReadInt(offset + 0x4); } }
        public string name { get { return d3.ReadString(offset + 0x8, 128); } }
        public int snoid { get { return d3.ReadInt(offset + 0x88); } }
        public int worldid { get { return d3.ReadInt(offset + 0xD8); } }
        public int sceneid { get { return d3.ReadInt(offset + 0xDC); } }

        private ACD _acd;
        public ACD acd
        {
            get
            {
                if (_acd == null)
                    _acd = d3.GetACDByACDGUID(acdguid);
                return _acd;
            }
        }

        public Actor(int ofs)
        {
            this.offset = ofs;
            aguidvalid = actor_guid;
            guidvalid = acdguid;
        }

        public int GetInt(Attrib attrib)
        {
            if (acd == null)
                return -1;
            return acd.GetInt(attrib);
        }

        public float GetFloat(Attrib attrib)
        {
            if (acd == null)
                return -1;
            return acd.GetFloat(attrib);
        }

        public override string ToString()
        {
            return name;
        }

        public bool IsValid()
        {
            return actor_guid == aguidvalid && acdguid == guidvalid;
        }
    }
}
