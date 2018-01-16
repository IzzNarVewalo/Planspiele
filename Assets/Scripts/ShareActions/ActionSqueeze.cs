using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionSqueeze : ShareAction
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
        _instructionText.text = "Squeeze the Device. (or F to squeeze)";
    }

    // Update is called once per frame
    void Update()
    {
        if (_active)
        {
            if ((inS.GetForce() > GameSettings.forceThreshold))
            {
                howLong = howLong + Time.deltaTime;
                Debug.Log(howLong / Duration);
                if (playSound)
                    SoundEffectManager.Instance.PlaySplash();
            }
            else
            {
                playSound = true;
            }

            if (howLong > Duration)
            {
                _instructionText.text = "You have squeezed enough. Put the Share-Device down.";
            }

            if (!inS.IsPickedUp())
            {
                //Return the time value
                finished = true;
            }

        }
    }
}
