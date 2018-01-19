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

    public override void ExitAction()
    {
        Debug.Log("Blaaa");
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
