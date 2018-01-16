using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionRotateSqueeze : ActionAddIngredient
{
    private bool finished = false;
    private bool playSound = true;
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
        ShowInstructionText("Rotate the Share-Device and squeeze it.");
    }

    // Update is called once per frame
    void Update()
    {
        if (_active)
        {
            if ((inS.GetForce() > GameSettings.forceThreshold && inS.GetTiltAngle() > GameSettings.tiltThreshold))
            {
                howLong = howLong + Time.deltaTime;
                UpdateIngredientProgress(howLong / Duration);
                if (playSound)
                {
                    SoundEffectManager.Instance.PlaySauceSqueezing();
                    playSound = false;
                }
                    
            }
            else
            {
                playSound = true;
                
            }
            
            if (howLong > Duration)
            {
                ShowInstructionText("You have added enough. Put the Share-Device down.");
            }

            if (!inS.IsPickedUp())
            {
                //Return the time value
                finished = true;
            }

        }
    }
}