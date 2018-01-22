using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionPickUpCup : ShareAction {

    private bool pickedUp = false;

    public override bool Finished()
    {
        return pickedUp;
    }

    public override void EnterAction()
    {
        Debug.Log("Enter ActionPickUpCup Action");

        _active = true;
        _instructionText.text = "Pick up the Share Device or press V";

    }

    protected override void SetInstructionImages()
    {
        instructionImages = new Sprite[2];
        instructionImages[0] = Resources.Load<Sprite>("Take1");
        instructionImages[1] = Resources.Load<Sprite>("Take2");
    }

    public override void ExitAction()
    {
        SoundEffectManager.Instance.PlayLiftCup();
    }

    // Update is called once per frame
    void Update () {
        if (_active)
        {
            if (ShareInputManager.ShareInput.IsPickedUp())
            {
                pickedUp = true;
            }
        }
	}
}
