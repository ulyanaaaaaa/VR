using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PhysicsProjectile : Projectile
{
    [SerializeField] private float _lifeTime;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public override void Init(Weapon weapon)
    {
        base.Init(weapon);
        Destroy(gameObject, _lifeTime);
    }

    public override void Launch()
    {
        base.Launch();
        
        Vector3 launchDirection = _weapon.transform.forward; 
        _rigidbody.AddForce(launchDirection * _weapon.ShootingForce, ForceMode.Impulse);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IDamageable damage))
        {
            damage.TakeDamage(_weapon, this, transform.position);
        }
    }
}
