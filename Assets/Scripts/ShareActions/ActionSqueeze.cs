using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionSqueeze : ActionAddIngredient
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
        Debug.Log("Enter ActionSqueeze Action");
        inS = ShareInputManager.ShareInput;
        _active = true;
        ShowInstructionText("Squeeze the Device.");
    }

    // Update is called once per frame
    void Update()
    {
        if (_active)
        {
            if ((inS.GetForce() > GameSettings.forceThreshold))
            {
                howLong = howLong + Time.deltaTime;
                UpdateIngredientProgress(howLong / Duration);
                if (playSound)
                    SoundEffectManager.Instance.PlaySplash();
            }
            else
            {
                playSound = true;
            }
            

            if (howLong > Duration)
            {
                ShowInstructionText("You have squeezed enough. Put the Share-Device down.");
            }

            if (!inS.IsPickedUp())
            {
                //Return the time value
                finished = true;
            }

        }
    }
}
