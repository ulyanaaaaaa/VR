using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(XRGrabInteractable))]
public class Weapon : MonoBehaviour
{
    [field: SerializeField] public float ShootingForce { get; private set; }
    [field: SerializeField] public float Damage { get; private set; }
    [SerializeField] protected float _recoilForce;
    [SerializeField] protected Transform _bulletSpawn;

    private Rigidbody _rigidbody;
    private XRGrabInteractable _grabInteractable;

    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _grabInteractable = GetComponent<XRGrabInteractable>();

        SetupInteractableWeaponEvents();
    }

    private void SetupInteractableWeaponEvents()
    {
        _grabInteractable.onHoverEntered.AddListener(PickUpWeapon);
        _grabInteractable.onHoverExited.AddListener(DropWeapon);
        _grabInteractable.onActivate.AddListener(StartShooting);
        _grabInteractable.onDeactivate.AddListener(StopShooting);
    }

    protected virtual void StopShooting(XRBaseInteractor arg0)
    {
        
    }

    protected virtual void StartShooting(XRBaseInteractor arg0)
    {
        Shoot();
    }

    protected virtual void Shoot()
    {
        ApplyRecoil();
    }

    protected virtual void PickUpWeapon(XRBaseInteractor interactor)
    {
        
    }
    
    protected virtual void DropWeapon(XRBaseInteractor interactor)
    {
        
    }

    private void ApplyRecoil()
    {
        _rigidbody.AddRelativeForce(Vector3.back * _recoilForce, ForceMode.Impulse);
    }

    private void OnDestroy()
    {
        if (_grabInteractable != null)
        {
            _grabInteractable.onHoverEntered.RemoveListener(PickUpWeapon);
            _grabInteractable.onHoverExited.RemoveListener(DropWeapon);
            _grabInteractable.onActivate.RemoveListener(StartShooting);
        }
    }
}