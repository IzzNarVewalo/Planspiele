using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionSelectCoffee : ShareAction {

    bool finished = false;

    public override bool Finished()
    {
        return finished;
    }

    protected override void SetInstructionImages()
    {
        instructionImages = null;
    }

    public override void EnterAction()
    {
        base.EnterAction();
        CupMovement cupMovement = FindObjectOfType<CupMovement>();
        cupMovement.LockMovement = true;

        Coroutines.AnimatePosition(cupMovement.gameObject, Vector3.one, this);
    }

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
