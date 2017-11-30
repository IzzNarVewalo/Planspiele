using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugInput : MonoBehaviour, IShareInput {

    private float _force = 0;

    private Quaternion _rotation = Quaternion.identity;

    private bool _isPickedUp = false;

    public Vector3 GetAccelerationRaw()
    {
        return Vector3.zero;
    }

    public float GetForce()
    {
        return _force;
    }

    public Quaternion GetRotation()
    {
        return _rotation;
    }

    public float GetTiltAngle()
    {
        return Quaternion.Angle(Quaternion.identity, _rotation);
    }

    public bool IsPickedUp()
    {
        return _isPickedUp;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        CheckForce();
        CheckRotation();
	}

    void CheckForce()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            _force = Mathf.Clamp(_force + Time.deltaTime * 500, -5, 5000);
        }
        else
        {
            _force = Mathf.Clamp(_force - Time.deltaTime * 500, -5, 5000);
        }
    }

    void CheckRotation()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Quaternion.RotateTowards(_rotation, Quaternion.Euler(0, 0, (horizontal / Mathf.Abs(horizontal)) * 70), Mathf.Abs(horizontal) * Time.deltaTime);
    }

    void CheckPickUp()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            _isPickedUp = !_isPickedUp;
        }
    }
}
