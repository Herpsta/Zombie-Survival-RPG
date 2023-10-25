using System.Collections.Generic;
using UnityEngine;

    public class Stat : MonoBehaviour
    {
        public float CurrentValue { get; private set; } // Make setter private to control its modification
        public float MaxValue { get; set; }
        public Dictionary<string, float> TempModifiers { get; private set; } // Make setter private to control its modification

        [Tooltip("Persistent modifiers that affect the stat value")]
        public Dictionary<string, float> PersistentModifiers { get; private set; } // Make setter private to control its modification

        public Stat(float currentValue, float maxValue)
        {
            CurrentValue = currentValue;
            MaxValue = maxValue;
            TempModifiers = new Dictionary<string, float>();
            PersistentModifiers = new Dictionary<string, float>();
        }

        public void ApplyTempModifier(string statName, float modifierValue)
        {
            TempModifiers[statName] = modifierValue;
            UpdateCurrentValue();
        }

        public void RemoveTempModifier(string statName)
        {
            if (TempModifiers.ContainsKey(statName)) // Check if the key exists before trying to remove it
            {
                TempModifiers.Remove(statName);
                UpdateCurrentValue();
            }
        }

        public void ApplyPersistentModifier(string statName, float modifierValue)
        {
            PersistentModifiers[statName] = modifierValue;
            UpdateCurrentValue();
        }

        public void RemovePersistentModifier(string statName)
        {
            if (PersistentModifiers.ContainsKey(statName)) // Check if the key exists before trying to remove it
            {
                PersistentModifiers.Remove(statName);
                UpdateCurrentValue();
            }
        }

        public delegate void StatChanged(float newValue);
        public event StatChanged OnStatChanged;

        public void ResetAllTempModifiers()
        {
            TempModifiers.Clear();
            UpdateCurrentValue();
        }

        private void UpdateCurrentValue()
        {
            // Reset CurrentValue to MaxValue
            CurrentValue = MaxValue;

            // Apply each modifier
            foreach (var modifier in TempModifiers.Values)
            {
                CurrentValue -= modifier;
            }

            // Apply each persistent modifier
            foreach (var modifier in PersistentModifiers.Values)
            {
                CurrentValue -= modifier;
            }

            // Ensure CurrentValue does not exceed MaxValue or fall below 0
            CurrentValue = Mathf.Clamp(CurrentValue, 0, MaxValue);

            // Trigger the event
            OnStatChanged?.Invoke(CurrentValue);
        }
    }