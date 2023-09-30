using System.Collections.Generic;
using ZGCore;

namespace ZGItems
{
    public class FoodItem : BaseItem, IFood, IIngredient
    {
        public FoodItem(string name, string description, Dictionary<string, Stat> stats) : base(name, description, stats) { }

        public void Eat()
        {
            // Eating logic here
        }

        public void Craft()
        {
            // Crafting logic here
        }
    }
}
