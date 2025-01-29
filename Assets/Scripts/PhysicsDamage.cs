using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PhysicsDamage : MonoBehaviour, IDamageable
{
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    
    public void TakeDamage(Weapon weapon, Projectile projectile, Vector3 contactPoint)
    {
        Destroy(gameObject);
        _rigidbody.AddForce(projectile.transform.forward * weapon.ShootingForce, ForceMode.Impulse);
    }
}
