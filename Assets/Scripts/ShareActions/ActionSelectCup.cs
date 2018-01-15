using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionSelectCup : ShareAction {

    private bool selected = false;

    public override void EnterAction()
    {
        Debug.Log("Enter ActionSelectCup Action");
        // TODO: Wechsle durch Cups durch
        _active = true;
        _instructionText.text = "To select the cup, pick up the Share Device.";
    }

    public override bool Finished()
    {
        return selected;
    }
	
	// Update is called once per frame
	void Update () {
        if (_active)
        {
            if (ShareInputManager.ShareInput.IsPickedUp())
            {
                selected = true;
                _instructionText.text = "Cup selected!";
                Debug.Log("Cup Selected!");
            }
        }
	}
}
