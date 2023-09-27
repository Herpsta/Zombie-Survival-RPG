namespace ZombieGame.World
{
    using System;
    using System.Collections.Generic;
    using ZombieGame.Items;
    using ZombieGame.Core;
    
    public class Container
    {
        public List<BaseItem> Items { get; set; }
        public double ChanceToContainItem { get; set; }

        public Container()
        {
            Items = new List<BaseItem>();
            ChanceToContainItem = 0.5;  // 50% chance by default
        }

        public void AddItem(BaseItem item)
        {
            Items.Add(item);
        }

        public BaseItem RemoveItem(BaseItem item)
        {
            Items.Remove(item);
            return item;
        }
    }
}
