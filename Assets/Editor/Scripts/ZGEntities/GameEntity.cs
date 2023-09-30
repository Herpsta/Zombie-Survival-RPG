using System;
using System.Collections.Generic;
using ZGCore;

namespace ZGEntities
{    
    public class GameEntity
    {
        public Stat Health { get; set; }
        public Stat Hunger { get; set; }
        public Stat Oxygen { get; set; }
        public Stat Temperature { get; set; }
        public Stat Stamina { get; set; }
        public Stat Speed { get; set; }
        public float LocationX { get; set; }
        public float LocationY { get; set; }
        public float LocationZ { get; set; }

        public Dictionary<string, float> TempModifiers { get; set; }

        public GameEntity(Stat health, Stat hunger, Stat oxygen, Stat temperature, Stat stamina, Stat speed, float locationX, float locationY, float locationZ)
        {
            Health = health;
            Hunger = hunger;
            Oxygen = oxygen;
            Temperature = temperature;
            Stamina = stamina;
            Speed = speed;
            LocationX = locationX;
            LocationY = locationY;
            LocationZ = locationZ;
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

        public virtual void TakeDamage(float damage)
        {
            Health.CurrentValue -= damage;
        }

        public virtual void PerformAction(float staminaCost)
        {
            Stamina.CurrentValue -= staminaCost;
        }

        public virtual void Move(float dx, float dy, float dz)
        {
            LocationX += dx;
            LocationY += dy;
            LocationZ += dz;
        }

        public void ReplenishHealth(float amount)
        {
            Health.CurrentValue = Math.Min(Health.CurrentValue + amount, Health.MaxValue);
        }

        public void ReplenishHunger(float amount)
        {
            Hunger.CurrentValue = Math.Min(Hunger.CurrentValue + amount, Hunger.MaxValue);
        }

        public void ReplenishOxygen(float amount)
        {
            Oxygen.CurrentValue = Math.Min(Oxygen.CurrentValue + amount, Oxygen.MaxValue);
        }

        public void ReplenishTemperature(float amount)
        {
            Temperature.CurrentValue = Math.Min(Temperature.CurrentValue + amount, Temperature.MaxValue);
        }

        public void ReplenishStamina(float amount)
        {
            Stamina.CurrentValue = Math.Min(Stamina.CurrentValue + amount, Stamina.MaxValue);
        }
    }
}
