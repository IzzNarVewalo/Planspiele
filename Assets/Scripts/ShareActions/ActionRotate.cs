using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionRotate : ActionAddIngredient {

    public float tiltAngleThreshold;

    private bool finished = false;
    
    private float howLong = 0;

    public float Duration = 5;

    IShareInput shareInput;

    private bool _playSound = false;

    public override bool Finished()
    {
        return finished;
    }

    public override void EnterAction()
    {
        Debug.Log("Enter ActionRotate Action");
        shareInput = ShareInputManager.ShareInput;
        _active = true;
        ShowInstructionText("Rotate the Share Device to add the ingredient!");
    }
    public override void ExitAction()
    {
        Debug.Log("Exit ActionRotate Action");
        ProgressBarScript.value = 0;
    }
    protected override void SetInstructionImages()
    {
        instructionImages = new Sprite[2];
        instructionImages[0] = Resources.Load<Sprite>("Turn1");
        instructionImages[1] = Resources.Load<Sprite>("Turn2");
    }

    // Update is called once per frame
    new void Update () {

        if (_active)
        {

            base.Update();
            
            if (shareInput.GetTiltAngle() > GameSettings.TiltThreshold)
            {
                //Debug.Log("Tilt angle: " + shareInput.GetTiltAngle());
                howLong = howLong + Time.deltaTime;
                UpdateIngredientProgress(howLong / Duration);

                if (_playSound)
                {
                    _playSound = false;
                    SoundEffectManager.Instance.PlaySplash();
                }
            } else
            {
                if (!_playSound)
                {
                    _playSound = true;
                    SoundEffectManager.Instance.StopSplash();
                }
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
