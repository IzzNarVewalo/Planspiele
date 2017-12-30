using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionSqueeze : ShareAction {

    public float forceThreshold;
    public float tiltThreshold;

    private bool finished = false;

    private float howLong = 0;
    IShareInput inS;

    public override bool Finished()
    {
        return finished;
    }


    public override void EnterAction()
    {
        Debug.Log("Enter ActionRotateSqueeze Action");

        _active = true;
        debugText.text = "Squeeze the ShareDevice or press Q";
    }

	// Update is called once per frame
	void Update () {
        if (_active)
        {
            if (!ShareInputManager.ShareInput.IsPickedUp())
            {
                //Return the time value
                finished = true;
            }

        }


	}
}
