using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionSelectIngredient : ShareAction {

    private bool _ingredientSelected = false;

    private IShareInput _shareInput;

    private RotatingPicker _rotatingPicker;

    private static string _rotatingPickerName = "IngredientPicker";

    public override bool Finished()
    {
        throw new System.NotImplementedException();
    }

    public override void EnterAction()
    {
        Debug.Log("Enter ActionSelectIngredient Action");
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
            // 
            if(_shareInput.GetForce() >= GameSettings.forceThreshold)
            {
                if(_rotatingPicker != null)
                {
                    GameData.SelectedIngredient = _rotatingPicker.Select();
                    _ingredientSelected = true;
                }
                SoundEffectManager.Instance.PlayLiftCup();
            }
        }
	}
}
