using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionRotate : ActionAddIngredient {

    public float tiltAngleThreshold;

    private bool finished = false;
    
    private float howLong = 0;

    public float Duration = 5;

    IShareInput shareInput;

    public override bool Finished()
    {
        return finished;
    }

    public override void EnterAction()
    {
        Debug.Log("Enter ActionRotate Action");
        shareInput = ShareInputManager.ShareInput;
        _active = true;
        ProgressBarScript.value = 0;
        ShowInstructionText("Rotate the Share Device to add the ingredient!");
    }
    
    // Update is called once per frame
    void Update () {

        if (_active)
        {
            
            if (shareInput.GetTiltAngle() > GameSettings.tiltThreshold)
            {
                //Debug.Log("Tilt angle: " + shareInput.GetTiltAngle());
                howLong = howLong + Time.deltaTime;
                ProgressBarScript.value = howLong / Duration;
                UpdateIngredientProgress(howLong / Duration);
            }

            if (howLong > Duration)
            {
                ShowInstructionText("You have added enough. Put the Share-Device down.");
            }

            if (!shareInput.IsPickedUp())
                finished = true;

        }


	}
}
