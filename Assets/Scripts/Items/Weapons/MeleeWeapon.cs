using UnityEngine;

public class MeleeWeapon : MonoBehaviour, IWeapon
{
    // ... Other properties ...

    public void PrimaryAction()
    {
        // Regular attack logic
    }

    public void SecondaryAction()
    {
        // Kick logic
    }

    public void Block()
    {
        // Block logic
    }

    public void Reload()
    {
        // Nothing happens for melee weapons
    }

    public void PowerAttack()
    {
        // Power attack logic
    }
}