using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionPickUpCup : ShareAction {

    private bool pickedUp = false;

     IShareInput inS;

    public override bool Finished()
    {
        return pickedUp;
    }

    public override void EnterAction()
    {
        Debug.Log("Enter ActionPickUpCup Action");

        _active = true;
        debugText.text = "Pick up the Share Device or press U";

    }

    // Update is called once per frame
    void Update () {

        if (inS.IsPickedUp()||Input.GetKey(KeyCode.U))
        {
            pickedUp = true;
        }


	}
}
