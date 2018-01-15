using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionSelectIngredient : ShareAction {

    private bool _ingredientSelected = false;

    public override bool Finished()
    {
        throw new System.NotImplementedException();
    }

    public override void EnterAction()
    {
        Debug.Log("Enter ActionSelectIngredient Action");
        _active = true;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (_active)
        {

        }
	}
}
