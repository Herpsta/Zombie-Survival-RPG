using System.Collections.Generic;
using ZGCore;

namespace ZGItems
{    
    public class Item
    {
        private readonly ItemType meleeWeapon;
        private readonly Dictionary<string, Stat> dictionary;

        public string Name { get; set; }
        public string Description { get; set; }
        public ItemType Type { get; set; }
        public Dictionary<string, Stat> Stats { get; set; }
        public int Id { get; set; }

        public Item(string name, string description, ItemType type, Dictionary<string, Stat> stats, object value, int id)
        {
            Name = name;
            Description = description;
            Type = type;
            Stats = stats;
            Id = id;
        }

        public Item(string name, string description, ItemType meleeWeapon, Dictionary<string, Stat> dictionary)
        {
            Name=name;
            Description=description;
            this.meleeWeapon=meleeWeapon;
            this.dictionary=dictionary;
        }
    }
}
