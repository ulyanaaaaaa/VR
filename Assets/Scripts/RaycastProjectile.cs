using UnityEngine;

public class RaycastProjectile : Projectile
{
    public override void Launch()
    {
        base.Launch();
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            IDamageable[] damageables = hit.collider.GetComponentsInChildren<IDamageable>();
            
            foreach (IDamageable damageable in damageables)
            {
                damageable.TakeDamage(_weapon, this, hit.point);    
            }
        }
    }
}
