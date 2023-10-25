using System.Collections.Generic;
using UnityEngine;

public class Room
{
        [Tooltip("Dictionary containing the exits from the room, with the direction as the key and the room as the value.")]
        private Dictionary<Direction, Room> exits;
        public Dictionary<Direction, Room> Exits { get { return exits; } set { exits = value; } }

        [Tooltip("List of entities present in the room.")]
        private List<GameEntity> entities;
        public List<GameEntity> Entities { get { return entities; } set { entities = value; } }

        [Tooltip("List of items present in the room.")]
        private List<BaseItem> items;
        public List<BaseItem> Items { get { return items; } set { items = value; } }

        public Room()
        {
            Exits = new Dictionary<Direction, Room>();
            Entities = new List<GameEntity>();
            Items = new List<BaseItem>();
        }
}