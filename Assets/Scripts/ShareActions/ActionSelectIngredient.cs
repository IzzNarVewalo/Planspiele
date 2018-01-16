using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionSelectIngredient : ShareAction {

    private bool _ingredientIsSelected = false;

    private Ingredient _selectedIngredient = null;

    private IShareInput _shareInput;

    private RotatingPicker _rotatingPicker;
    
    private static string _rotatingPickerName = "IngredientPicker";

    public override bool Finished()
    {
        return _ingredientIsSelected;
    }

    public override void EnterAction()
    {
        Debug.Log("Enter ActionSelectIngredient Action");
        ShowInstructionText("Pick up the cup to stop the rotation and select the ingredient.");
        _shareInput = ShareInputManager.ShareInput;
        _active = true;
        _rotatingPicker = GameObject.Find(_rotatingPickerName).GetComponent<RotatingPicker>();
        if(_rotatingPicker == null)
        {
            Debug.LogError("Couldn't find the Rotating Picker with name '"+_rotatingPickerName+"' in the scene!");
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (_active)
        {
            if(_rotatingPicker != null)
            {
                if (_shareInput.IsPickedUp())
                {
                    if(_selectedIngredient == null)
                    {
                        SoundEffectManager.Instance.PlayLiftCup();
                        _selectedIngredient = _rotatingPicker.Select();
                    }

                    if(_shareInput.GetForce() >= GameSettings.ForceThreshold)
                    {
                        _ingredientIsSelected = true;
                        GameData.SelectedIngredient = _selectedIngredient;
                    }

                } else
                {
                    if(_selectedIngredient != null)
                    {
                        _selectedIngredient = null;
                        _rotatingPicker.Rotate();
                    }
                }
            }

            if(_shareInput.GetForce() >= GameSettings.ForceThreshold)
            {
                if(_rotatingPicker != null)
                {
                    GameData.SelectedIngredient = _rotatingPicker.Select();
                    _ingredientIsSelected = true;
                }
                
            }
        }
	}
}
