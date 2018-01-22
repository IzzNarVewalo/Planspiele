using System;
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

    public delegate void PlaySoundMethod();
    PlaySoundMethod _playSoundMethod;
    PlaySoundMethod _stopSoundMethod;

    public override bool Finished()
    {
        return finished;
    }

    public void SetSoundMethods(PlaySoundMethod playSoundMethod, PlaySoundMethod stopSoundMethod, bool add = true)
    {
        if (add)
        {
            _playSoundMethod += playSoundMethod;
            _stopSoundMethod += stopSoundMethod;
        }
        else
        {
            _playSoundMethod = playSoundMethod;
            _stopSoundMethod = stopSoundMethod;
        }
            
    }

    public override void ExitAction()
    {
        base.ExitAction();
        if (GameData.SelectedIngredient != null&&GameData.SelectedIngredient.GetProgress() < 1.0f)
            GameData.SelectedIngredient.SetProgress(2.0f - GameData.SelectedIngredient.GetProgress());
        ProgressBarScript.value = 0;
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
        _playSoundMethod = SoundEffectManager.Instance.PlaySplash;
        _stopSoundMethod = SoundEffectManager.Instance.StopSplash;
        _active = true;
        ShowInstructionText("Squeeze the Device.");
        SetInstructionImages();
    }

    // Update is called once per frame
    new void Update()
    {
       
        if (_active)
        {
            base.Update();
            if ((inS.GetForce() > GameSettings.ForceThreshold))
            {
                howLong = howLong + Time.deltaTime;
                UpdateIngredientProgress(howLong / Duration);
                if (playSound)
                {
                    _playSoundMethod();
                    playSound = false;
                }
                    
            }
            else
            {
                if (!playSound)
                {
                    _stopSoundMethod();
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
