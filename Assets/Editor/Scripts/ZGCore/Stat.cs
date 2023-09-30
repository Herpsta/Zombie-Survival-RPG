using System.Collections.Generic;

namespace ZGCore
{    
    public class Stat
    {
        public float CurrentValue { get; set; }
        public float MaxValue { get; set; }
        public Dictionary<string, float> TempModifiers { get; set; }

        public Stat(float currentValue, float maxValue)
        {
            CurrentValue = currentValue;
            MaxValue = maxValue;
            TempModifiers = new Dictionary<string, float>();
        }

        public void ApplyTempModifier(string statName, float modifierValue)
        {
            TempModifiers[statName] = modifierValue;
        }

        public void RemoveTempModifier(string statName)
        {
            TempModifiers.Remove(statName);
        }
    }
}
