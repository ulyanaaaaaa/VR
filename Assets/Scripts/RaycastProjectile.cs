using UnityEngine;

public class RaycastProjectile : Projectile
{
    public override void Launch()
    {
        base.Launch();
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.collider.TryGetComponent(out IDamageable damage))
            {
                damage.TakeDamage(_weapon, this, hit.point);
            }
        }
    }
}
