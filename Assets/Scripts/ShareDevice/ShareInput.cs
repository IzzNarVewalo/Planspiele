using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShareInput : MonoBehaviour, IShareInput {

    private Communication _communication;

    private CircularBuffer<float> _activityBuffer;

    private int _activitiesPerSecond = 20;

    private float _activityMeasure;

    public Vector3 GetAccelerationRaw()
    {
        return _communication.RawAcceleration;
    }

    public float GetForce()
    {
        return _communication.force;
    }

    public Quaternion GetRotation()
    {
        return _communication.rotQuat;
    }

    public float GetTiltAngle()
    {
        return Vector3.Angle(Vector3.down, _communication.RawAcceleration);
    }

    public bool IsPickedUp()
    {
        // TODO: 
        throw new System.NotImplementedException();
    }

    void Awake()
    {
        Communication c = GetComponent<Communication>();
        if (c != null)
            _communication = c;
        else
        {
            c = FindObjectOfType<Communication>();
            if (c != null)
                _communication = c;
            else
                _communication = gameObject.AddComponent<Communication>();
        }
    }

    // Use this for initialization
    void Start () {
        StartCoroutine(ActivityLogger(_activitiesPerSecond));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator ActivityLogger(int timesPerSecond)
    {
        _activityBuffer = new CircularBuffer<float>(timesPerSecond);
        float waitTime = 1f / timesPerSecond;
        Quaternion lastRotation = GetRotation();
        Vector3 lastAcceleratin = GetAccelerationRaw();
        while (true)
        {
            yield return new WaitForSecondsRealtime(waitTime);
            float activity = Quaternion.Angle(lastRotation, GetRotation()) + (lastAcceleratin - GetAccelerationRaw()).magnitude;
            _activityBuffer.Push(activity);
        }
    }

    private float RecentActivitySum()
    {
        float sum = 0;
        foreach(float a in _activityBuffer)
        {
            sum += a;
        }
        return sum;
    }

}
