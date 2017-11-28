using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionAddIngredient : ShareAction {
    // The ingredient that should be added during this action
    private Ingredient _ingredient;

    public override bool Finished()
    {
        throw new System.NotImplementedException();
    }

    public static ShareAction Create<T>()
    {
        throw new Exception("Can't create ActionAddIngredient without Ingredient");
    }

    public static ActionAddIngredient Create(Ingredient ingredient)
    {
        GameObject g = new GameObject();
        ActionAddIngredient action = g.AddComponent<ActionAddIngredient>();
        action._ingredient = ingredient;
        return action;
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
