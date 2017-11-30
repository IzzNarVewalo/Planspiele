using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionRotateSqueeze : ShareAction {

    private bool finished = false;
    private bool cupFilled = false;

    private float howLong = 0;

    public override bool Finished()
    {
        return finished;
    }


    public override void EnterAction()
    {
        Debug.Log("Enter ActionRotateSqueeze Action");

        _active = true;
        debugText.text = "Rotate the Share Device and squeeze it or press Q";
    }

	// Update is called once per frame
	void Update () {
        if (_active)
        {
            if (Input.GetKey(KeyCode.Q))
            {
                howLong = howLong + Time.deltaTime;
                cupFilled = true;
            }

            if (!Input.GetKey(KeyCode.Q) && cupFilled)
            {
                //Return the time value
                finished = true;
            }

        }


	}
}
