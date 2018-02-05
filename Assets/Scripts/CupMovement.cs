using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CupMovement : MonoBehaviour {

    IShareInput _shareInput;

    public Transform _activeChild;

    public bool LockMovement;

    private Vector3 _activeChildPositionBeforePickUp;
    private Quaternion _activeChildRotationBeforePickup;
    private Transform _activeChildParentBeforePickUp;
    

    private void Awake()
    {
        _shareInput = ShareInputManager.ShareInput;
        if(transform.childCount > 0)
            _activeChild = transform.GetChild(0);
    }

    void Update()
    {
        if (_activeChild != null)
        {
            if (!LockMovement)
            {
                _activeChild.localRotation = Quaternion.Lerp(_activeChild.localRotation, Quaternion.Euler(0, 90, 0) * _shareInput.GetRotation(), 10 * Time.deltaTime);
            }
            else
            {
                _activeChild.localRotation = Quaternion.Lerp(_activeChild.localRotation, Quaternion.identity, 10 * Time.deltaTime);
            }
        } else if(transform.childCount > 0)
        {
            PickUpObject(transform.GetChild(0).gameObject);
        }
    }

    public void PickUpObject(GameObject objectToHold)
    {
        Vector3 lastPosition = transform.position;
        if (_activeChild != null)
            lastPosition = _activeChild.position;

        PutDownObject();

        _activeChildParentBeforePickUp = objectToHold.transform.parent;
        _activeChildPositionBeforePickUp = objectToHold.transform.position;
        _activeChildRotationBeforePickup = objectToHold.transform.rotation;
        _activeChild = objectToHold.transform;
        _activeChild.transform.parent = transform;

        Coroutines.AnimatePosition(_activeChild.gameObject, lastPosition, this, true);
    }

    public void PutDownObject()
    {
        if (_activeChild != null)
        {
            _activeChild.parent = _activeChildParentBeforePickUp;
            Coroutines.AnimatePosition(_activeChild.gameObject, _activeChildPositionBeforePickUp, this);
            Coroutines.AnimateRotation(_activeChild.gameObject, _activeChildRotationBeforePickup, this);
        }
    }
}
