using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionRotateSqueeze : ShareAction {

    public float forceThreshold;
    public float tiltThreshold;

    private bool finished = false;

    private float howLong = 0;
    IShareInput inS;

    public override bool Finished()
    {
        return finished;
    }


    public override void EnterAction()
    {
        Debug.Log("Enter ActionRotateSqueeze Action");

        _active = true;
        debugText.text = "Rotate the Share Device and squeeze it or press Q";
    }

	// Update is called once per frame
	void Update () {
        if (_active)
        {
            if ((inS.GetForce()> GameSettings.forceThreshold && inS.GetTiltAngle() > GameSettings.tiltThreshold)||Input.GetKey(KeyCode.Q))
            {
                howLong = howLong + Time.deltaTime;
                
            }

            if (!inS.IsPickedUp()||!Input.GetKey(KeyCode.Q))
            {
                //Return the time value
                finished = true;
            }

        }


	}
}
