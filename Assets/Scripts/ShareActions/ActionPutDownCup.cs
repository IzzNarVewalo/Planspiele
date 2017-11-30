using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionPutDownCup : ShareAction {

    private bool satDown = false;

    IShareInput inS;

    public override bool Finished()
    {
       return satDown;
    }

    public override void EnterAction()
    {
        Debug.Log("Enter ActionPutDownCup Action");

        _active = true;
        debugText.text = "Put down the Share Device or press D";

    }

    // Update is called once per frame
    void Update()
    {

        if (!inS.IsPickedUp()||Input.GetKey(KeyCode.D))
        {
            satDown = true;
        }


    }
}
