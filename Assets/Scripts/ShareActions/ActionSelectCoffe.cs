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
        
        float coffeeCupOffset = 0;
        MeshFilter meshFilter = cupMovement._activeChild.GetComponent<MeshFilter>();
        if(meshFilter != null)
        {
            coffeeCupOffset = meshFilter.mesh.bounds.extents.y / 2;
            Debug.Log(cupMovement.transform.position);
            Debug.Log(meshFilter.mesh.bounds.extents);
        }
        GameObject fillInCoffePosition = GameObject.FindGameObjectWithTag("FillInCoffeeZone");
        Vector3 animateCupTo = fillInCoffePosition.transform.position + new Vector3(0, coffeeCupOffset, 0);
        Vector3 cameraPosition = Camera.main.transform.position;
        cameraPosition.x = fillInCoffePosition.transform.position.x;
        if(fillInCoffePosition != null)
        {
            Coroutines.AnimatePosition(cupMovement.gameObject, animateCupTo, this);
            Coroutines.AnimatePosition(Camera.main.gameObject, cameraPosition, this);
        } else
        {
            Debug.LogError("Couldn't find the CoffeeMachine Position to animate the coffee cup to.");
        }
        
    }

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
