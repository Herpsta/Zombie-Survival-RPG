using UnityEngine;

public class RangedWeapon : MonoBehaviour, IWeapon
{
    public GameObject projectilePrefab;
    public Transform projectileSpawnPoint;
    // ... Other properties ...

    public void PrimaryAction()
    {
        // Shoot logic
        FireProjectile();
    }

    public void SecondaryAction()
    {
        // Zoom logic or alternate fire mode
    }

    public void Block()
    {
        // Perhaps block with the weapon or do nothing
    }

    public void Reload()
    {
        // Reload logic
    }

    public void PowerAttack()
    {
        // Bash logic
    }

    private void FireProjectile()
    {
        // Instantiate and fire projectile
    }
}