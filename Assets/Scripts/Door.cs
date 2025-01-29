using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(XRGrabInteractable))]
public class Door : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private XRGrabInteractable _grabInteractable;
    private bool _isOpen;

    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _grabInteractable = GetComponent<XRGrabInteractable>();

        SetupInteractableDoorEvents();
    }

    private void Start()
    {
        
    }

    [Obsolete("Obsolete")]
    private void SetupInteractableDoorEvents()
    {
        _grabInteractable.onSelectEnter.AddListener(ChangeState);
    }

    private void ChangeState(XRBaseInteractor arg0)
    {
        Debug.Log("OpenOrClose");
        if (_isOpen)
        {
            
        }
        else
        {
           
        }

        _isOpen = !_isOpen;
    }
}
