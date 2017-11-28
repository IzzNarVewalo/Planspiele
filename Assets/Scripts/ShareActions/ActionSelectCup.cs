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
        debugText.text = "To select the cup, squeeze the Share Device, or press C.";
    }

    public override bool Finished()
    {
        return selected;
    }
	
	// Update is called once per frame
	void Update () {
        if (_active)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                selected = true;
                debugText.text = "Cup selected!";
                Debug.Log("Cup Selected!");
            }
        }
	}
}
