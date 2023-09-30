using System;
using System.Collections.Generic;
using ZGEntities;
using ZGItems;
using ZGCore;

namespace ZGWorld
{   
    public class Room
    {
        public Dictionary<Direction, Room> Exits { get; set; }
        public List<GameEntity> Entities { get; set; }
        public List<BaseItem> Items { get; set; }

        public Room()
        {
            Exits = new Dictionary<Direction, Room>();
            Entities = new List<GameEntity>();
            Items = new List<BaseItem>();
        }
    }
}
