using System.Collections.Generic;
 
public class WeaponItem : BaseItem, IWeapon
{
        public WeaponItem(string name, string description, Dictionary<string, Stat> stats) : base(name, description, stats) { }

        public void Attack()
        {
            // Attack logic here
        }
}