using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CupMovementShare : MonoBehaviour {

    float valueX;
    float valueY;

    bool pickedUp = false;
    public float speed;
    
    public float ldrThreshold;
    private float ldrSmoothed;
    public float forceThreshold;

    public UnityEvent onPickup;

    Communication com;

    void Start()
    {
        com = GameObject.FindGameObjectsWithTag("MainCamera")[0].GetComponent<Communication>();
        onPickup.AddListener(new UnityAction(OnPickup));
    }

    private void OnPickup()
    {
        Debug.Log("[Event] Picked up!");
    }

    void Update()
    {

        checkLdr();
        transform.localRotation = com.rotQuat;
    }

    private void checkLdr()
    {
        ldrSmoothed = (ldrSmoothed + com.ldr) / 2;
        if (ldrSmoothed < ldrThreshold || Input.GetKeyDown(KeyCode.L))
        {
            if (!pickedUp)
                onPickup.Invoke();// Vector3.Angle(Vector3.up, com.RawAcceleration));

            pickedUp = true;
        }
        else
        {
            pickedUp = false;
        }
    }
}
