﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionPutDownCup : ShareAction {

    private bool satDown = false;

    public override bool Finished()
    {
        SoundEffectManager.Instance.PlayPutCup();
       return satDown;
    }

    public override void EnterAction()
    {
        Debug.Log("Enter ActionPutDownCup Action");

        _active = true;
        _instructionText.text = "Put down the Share Device or press D";

    }

    // Update is called once per frame
    void Update()
    {

        if (!ShareInputManager.ShareInput.IsPickedUp())
        {
            satDown = true;
        }


    }
}
