using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionRotate : ShareAction {

    public float tiltAngleThreshold;

    private bool finished = false;
    
    private float howLong = 0;

    IShareInput inS;

    public override bool Finished()
    {
        return finished;
    }

    public override void EnterAction()
    {
        Debug.Log("Enter ActionRotate Action");

        _active = true;
        debugText.text = "Rotate the Share Device or press R";
    }
    
    // Update is called once per frame
    void Update () {

        if (_active)
        {
            if (inS.GetTiltAngle() > GameSettings.tiltThreshold ||Input.GetKey(KeyCode.R))
            {
                howLong = howLong + Time.deltaTime;
            }

            if (!inS.IsPickedUp()||!Input.GetKey(KeyCode.R))
            {
                //Return the time value
                finished = true;
            }

        }


	}
}
