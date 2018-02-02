using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CupMovement : MonoBehaviour {

    IShareInput _shareInput;

    Transform _activeChild;

    public bool LockMovement;

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
            _activeChild = transform.GetChild(0);
        }
    }

}
