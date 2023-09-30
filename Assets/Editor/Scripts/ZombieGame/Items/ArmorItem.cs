using System.Collections.Generic;
using ZombieGame.Core;

namespace ZombieGame.Items
{    
    public class ArmorItem : BaseItem, IArmor
    {
        public ArmorItem(string name, string description, Dictionary<string, Stat> stats) : base(name, description, stats) { }

        public void Defend()
        {
            // Defense logic here
        }
    }
}
