using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Pistol : Weapon
{
    private Projectile _bulletPrefab;

    private void Start()
    {
        _bulletPrefab = Resources.Load<Projectile>("Bullet");
    }
    
    protected override void StartShooting(XRBaseInteractor interactor)
    {
        base.StartShooting(interactor);
        Shoot();
    }

    protected override void Shoot()
    {
        base.Shoot();
        Projectile projectile = Instantiate(_bulletPrefab, _bulletSpawn.position, Quaternion.identity, _bulletSpawn);
        projectile.Init(this);
        projectile.Launch();
    }

    protected override void StopShooting(XRBaseInteractor interactor)
    {
        base.StopShooting(interactor);
    }
}
