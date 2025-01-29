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
        Projectile bullet = Instantiate(_bulletPrefab, _bulletSpawn.position, Quaternion.identity);
        bullet.Init(this);
        bullet.Launch();
    }

    protected override void StopShooting(XRBaseInteractor interactor)
    {
        base.StopShooting(interactor);
    }
}
