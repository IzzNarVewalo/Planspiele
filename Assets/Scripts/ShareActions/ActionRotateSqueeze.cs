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

    protected override void SetInstructionImages()
    {
        
        instructionImages = new Sprite[2];
        instructionImages[0] = Resources.Load<Sprite>("TurnSqueeze2");
        instructionImages[1] = Resources.Load<Sprite>("TurnSqueeze1");
        
    }


    public override void EnterAction()
    {
        inS = ShareInputManager.ShareInput;
        _active = true;
        UpdateIngredientProgress(0);
        ShowInstructionText("Rotate the Share-Device and squeeze it.");
        SetInstructionImages();
    }

    public override void ExitAction()
    {
        base.ExitAction();
        if (GameData.SelectedIngredient != null && GameData.SelectedIngredient.GetProgress() < 1.0f)
            GameData.SelectedIngredient.SetProgress(2.0f - GameData.SelectedIngredient.GetProgress());
        ProgressBarScript.value = 0;
    }

    // Update is called once per frame
    new void Update()
    {
        if (_active)
        {
            base.Update();
            if ((inS.GetForce() > GameSettings.ForceThreshold && inS.GetTiltAngle() > GameSettings.TiltThreshold))
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
                if (!playSound)
                {
                    SoundEffectManager.Instance.StopSauceSqueezing();
                    playSound = true;
                }
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