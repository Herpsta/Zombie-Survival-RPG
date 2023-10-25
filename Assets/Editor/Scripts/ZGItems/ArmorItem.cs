using System.Collections.Generic;
using UnityEngine;
using ZGCore;

namespace ZGItems
{    
    public class ArmorItem : BaseItem, IArmor
    {
        [Tooltip("The amount of damage the armor can absorb")]
        public int armorValue; // Expose armor value in the inspector

        public ArmorItem(string name, string description, Dictionary<string, Stat> stats, int armorValue) : base(name, description, stats) 
        {
            this.armorValue = armorValue;
        }

        public void Defend()
        {
            // TODO: Implement the Defend() method logic.
            // For example, we can reduce the damage taken by the player by the armor value.
            // Assuming we have a Player class with a TakeDamage method, it could look like this:

            // Player player = ... // Get the player instance
            // player.TakeDamage(damage - armorValue); // Reduce the damage taken by the armor value
        }
    }
}