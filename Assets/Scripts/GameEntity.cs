using UnityEngine;
public class GameEntity : MonoBehaviour
{
        // Expose the stats in the inspector with tooltips
        [Tooltip("Health stat of the entity")]
        public Stat Health;
        [Tooltip("Hunger stat of the entity")]
        public Stat Hunger;
        [Tooltip("Oxygen stat of the entity")]
        public Stat Oxygen;
        [Tooltip("Temperature stat of the entity")]
        public Stat Temperature;
        [Tooltip("Stamina stat of the entity")]
        public Stat Stamina;
        [Tooltip("Speed stat of the entity")]
        public Stat Speed;
        [Tooltip("Armor stat of the entity")]
        public Stat Armor; // Added Armor stat
        [Tooltip("Mental Health stat of the entity")]
        public Stat MentalHealth; // Added Mental Health stat

        // Unity-specific components for 3D representation
        [Tooltip("Mesh Renderer of the entity")]
        public MeshRenderer MeshRenderer;
        [Tooltip("Mesh Filter of the entity")]
        public MeshFilter MeshFilter;
        [Tooltip("Rigidbody of the entity")]
        public Rigidbody Rigidbody;

        // State machine for handling entity states
        public enum EntityState { Idle, Moving, Attacking, Defending }
        public EntityState CurrentState { get; private set; }

        public void SetState(EntityState newState)
        {
            CurrentState = newState;
            // TODO: Handle state-specific logic here
        }

        public void TakeDamage(float damage)
        {
            Health.CurrentValue -= damage;
        }

        public void PerformAction(float staminaCost)
        {
            Stamina.CurrentValue -= staminaCost;
        }

        public void Move(Vector3 direction)
        {
            // Use Rigidbody to move the entity
            // Multiply the direction by Time.deltaTime and the speed stat for frame-rate independent movement
            // Use Vector3.Lerp for smoother movement
            Rigidbody.MovePosition(Vector3.Lerp(transform.position, transform.position + direction * Speed.CurrentValue, Time.deltaTime));
        }

        public void ReplenishHealth(float amount)
        {
            Health.CurrentValue = Mathf.Min(Health.CurrentValue + amount, Health.MaxValue);
        }

        public void ReplenishHunger(float amount)
        {
            Hunger.CurrentValue = Mathf.Min(Hunger.CurrentValue + amount, Hunger.MaxValue);
        }

        public void ReplenishOxygen(float amount)
        {
            Oxygen.CurrentValue = Mathf.Min(Oxygen.CurrentValue + amount, Oxygen.MaxValue);
        }

        public void ReplenishTemperature(float amount)
        {
            Temperature.CurrentValue = Mathf.Min(Temperature.CurrentValue + amount, Temperature.MaxValue);
        }

        public void ReplenishStamina(float amount)
        {
            Stamina.CurrentValue = Mathf.Min(Stamina.CurrentValue + amount, Stamina.MaxValue);
        }

        // TODO: Implement logic for entity interactions like attack, defend, etc.
        public void Attack(GameEntity target)
        {
            // Subtract the attack power from the target's health
            float attackPower = Speed.CurrentValue;  // Example
            target.TakeDamage(attackPower);
            SetState(EntityState.Attacking);
        }

        public void Defend(float defendValue)
        {
            // Increase the health by the defend value
            ReplenishHealth(defendValue);
            SetState(EntityState.Defending);
        }
}