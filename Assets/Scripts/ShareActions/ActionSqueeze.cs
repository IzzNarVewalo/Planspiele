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


    protected override void SetInstructionImages()
    {
        instructionImages = new Sprite[2];
        instructionImages[0] = Resources.Load<Sprite>("Squeeze1");
        instructionImages[1] = Resources.Load<Sprite>("Squeeze2");
    }


    public override void EnterAction()
    {
        Debug.Log("Enter ActionSqueeze Action");
        inS = ShareInputManager.ShareInput;
        _active = true;
        ShowInstructionText("Squeeze the Device.");
    }

    protected new void setInstructionImages()
    {
        instructionImages[0] = (Sprite)Resources.Load("Squeeze1");
        instructionImages[1] = (Sprite)Resources.Load("Squeeze2");
    }

    // Update is called once per frame
    void Update()
    {
        if (_active)
        {
            if ((inS.GetForce() > GameSettings.ForceThreshold))
            {
                howLong = howLong + Time.deltaTime;
                UpdateIngredientProgress(howLong / Duration);
                if (playSound)
                {
                    SoundEffectManager.Instance.PlaySplash();
                    playSound = false;
                }
                    
            }
            else
            {
                if (!playSound)
                {
                    SoundEffectManager.Instance.StopSplash();
                    playSound = true;
                }
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
