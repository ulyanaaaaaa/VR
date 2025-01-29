using UnityEngine;

public interface IDamageable
{
    public void TakeDamage(Weapon weapon, Projectile projectile, Vector3 contactPoint);
}
