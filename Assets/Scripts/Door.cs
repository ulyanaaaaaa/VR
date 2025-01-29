using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Door : MonoBehaviour
{
    [SerializeField] private Vector3 _openRotation; 
    [SerializeField] private Transform _transform; 
    [SerializeField] private float _openSpeed; 
    
    private XRBaseInteractable _interactable; 
    private Vector3 _closedRotation;
    private bool _isOpen;

    private void Start()
    {
        _interactable = GetComponent<XRGrabInteractable>();
        _closedRotation = _transform.eulerAngles;
        _interactable.selectEntered?.AddListener(OnDoorInteract);
    }

    private void OnDestroy()
    {
        _interactable.selectEntered?.RemoveListener(OnDoorInteract);
    }

    private void OnDoorInteract(SelectEnterEventArgs args)
    {
        if (!_isOpen)
        {
            OpenDoor();
        }
        else
        {
            CloseDoor();
        }
    }

    private void OpenDoor()
    {
        StopAllCoroutines();
        StartCoroutine(RotateDoor(_openRotation));
        _isOpen = true;
    }

    private void CloseDoor()
    {
        StopAllCoroutines();
        StartCoroutine(RotateDoor(_closedRotation));
        _isOpen = false;
    }

    private IEnumerator RotateDoor(Vector3 targetRotation)
    {
        while (Vector3.Distance(_transform.eulerAngles, targetRotation) > 0.01f)
        {
            _transform.eulerAngles = Vector3.Lerp(_transform.eulerAngles, targetRotation, Time.deltaTime * _openSpeed);
            yield return null;
        }
        _transform.eulerAngles = targetRotation;
    }
}
