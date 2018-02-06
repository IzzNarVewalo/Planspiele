using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionAddImmediate : ActionAddIngredient {

    bool _added = false;

    public override bool Finished()
    {
        return _added;
    }

    protected override void SetInstructionImages()
    {
        instructionImages = null;
    }

    public override void EnterAction()
    {
        base.EnterAction();
        if(!ReferenceEquals(GameData.SelectedIngredient, null))
        {
            UpdateIngredientProgress(1f);
            _added = true;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
