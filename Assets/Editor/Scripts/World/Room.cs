namespace ZombieGame.World
{
    using System;
    using System.Collections.Generic;
    using ZombieGame.Entities;
    using ZombieGame.Items;
    using ZombieGame.Core;
    
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
