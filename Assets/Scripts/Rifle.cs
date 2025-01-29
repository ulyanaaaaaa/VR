using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Rifle : Weapon
{
    [SerializeField] private float _fireRate;
    private Projectile _projectile;
    private Coroutine _shootTisk;

    protected override void Awake()
    {
        base.Awake();
        _projectile = GetComponentInChildren<Projectile>();
    }

    private void Start()
    {
        _projectile.Init(this);
    }

    protected override void StartShooting(XRBaseInteractor interactor)
    {
        base.StartShooting(interactor);
        _shootTisk = StartCoroutine(ShootTick());
    }

    private IEnumerator ShootTick()
    {
        while (true)
        {
            Shoot();
            yield return new WaitForSeconds(1 / _fireRate);
        }
    }

    protected override void Shoot()
    {
        base.Shoot();
        _projectile.Launch();
    }

    protected override void StopShooting(XRBaseInteractor interactor)
    {
        base.StopShooting(interactor);
        StopCoroutine(_shootTisk);
    }
}
