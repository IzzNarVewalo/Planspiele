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
        inS = ShareInputManager.ShareInput;
        _active = true;
        debugText.text = "Rotate the Share-Device and squeeze it. (Arrow-Keys to rotate, F to squeeze)";
    }

	// Update is called once per frame
	void Update () {
        if (_active)
        {
            if ((inS.GetForce()> GameSettings.forceThreshold && inS.GetTiltAngle() > GameSettings.tiltThreshold))
            {
                howLong = howLong + Time.deltaTime;
            }

            if(howLong > 5)
            {
                debugText.text = "You have squeezed enough. Put the Share-Device down. (V)";
            }

            if (!inS.IsPickedUp())
            {
                //Return the time value
                finished = true;
            }

        }


	}
}
