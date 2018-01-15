using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionRotateSqueeze : ShareAction
{
    private bool finished = false;

    private float howLong = 0;
    public float Duration = 5;
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
        _instructionText.text = "Rotate the Share-Device and squeeze it.";
    }

    // Update is called once per frame
    void Update()
    {
        if (_active)
        {
            if ((inS.GetForce() > GameSettings.forceThreshold && inS.GetTiltAngle() > GameSettings.tiltThreshold))
            {
                howLong = howLong + Time.deltaTime;
                Debug.Log(howLong / Duration);

            }

            if (howLong > Duration)
            {
                _instructionText.text = "You have added enough. Put the Share-Device down.";
            }

            if (!inS.IsPickedUp())
            {
                //Return the time value
                finished = true;
            }

        }
    }
}