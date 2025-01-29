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
        _rigidbody.AddRelativeForce(Vector3.forward * _weapon.ShootingForce, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        IDamageable[] damageables = other.GetComponentsInChildren<IDamageable>();

        foreach (IDamageable damageable in damageables)
        {
            damageable.TakeDamage(_weapon, this, transform.position);
        }
    }
}
