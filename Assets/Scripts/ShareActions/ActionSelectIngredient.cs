using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionSelectIngredient : ShareAction
{

    private bool _ingredientIsSelected = false;

    private Ingredient _selectedIngredient = null;

    private IShareInput _shareInput;

    private RotatingPicker _rotatingPicker;

    private static string _rotatingPickerName = "PlateHolder";

    public override bool Finished()
    {
        return _ingredientIsSelected;
    }


    protected override void SetInstructionImages()
    {
        instructionImages = null;
    }

    public override void EnterAction()
    {
        Debug.Log("Enter ActionSelectIngredient Action");
        ShowInstructionText("Pick up the cup to stop the rotation and select the ingredient.");
        _shareInput = ShareInputManager.ShareInput;
        _active = true;
        _rotatingPicker = GameObject.Find(_rotatingPickerName).GetComponentInChildren<RotatingPicker>();
        
        
        if (_rotatingPicker == null)
        {
            Debug.LogError("Couldn't find the Rotating Picker with name '" + _rotatingPickerName + "' in the scene!");
        } else
        {
            _rotatingPicker.Rotate();
            Vector3 cameraAnimatePosition = Camera.main.transform.position;
            cameraAnimatePosition.x = _rotatingPicker.transform.position.x;
            Coroutines.AnimatePosition(Camera.main.gameObject, cameraAnimatePosition, this);
        }
    }

    public override void ExitAction()
    {
        base.ExitAction();
        if(GameData.SelectedIngredient.GetIngredientType() == Ingredients.LargeCup || GameData.SelectedIngredient.GetIngredientType() == Ingredients.MediumCup || GameData.SelectedIngredient.GetIngredientType() == Ingredients.SmallCup)
        {
            _rotatingPicker.SetupPlate(RecipeManager._activeRecipe.GetIngredientsList());
        }
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_active)
        {
            if (_rotatingPicker != null)
            {
                if (_shareInput.IsPickedUp())
                {
                    if (_selectedIngredient == null)
                    {
                        SoundEffectManager.Instance.PlayLiftCup();
                        _selectedIngredient = _rotatingPicker.Select();
                    }

                    if (_shareInput.GetForce() >= GameSettings.ForceThreshold)
                    {
                        GameData.SelectedIngredient = null;
                        _ingredientIsSelected = true;

                        foreach (Ingredient ingredient in RecipeManager._activeRecipe.GetIngredientsList())
                        {
                            if (_selectedIngredient.GetIngredientType() == ingredient.GetIngredientType())
                            {
                                GameData.SelectedIngredient = ingredient;
                                Debug.Log("Found the corresponding ingredient!!");
                                    break;
                            }
                        }
                        if (GameData.SelectedIngredient == null)
                        {
                            GameData.SelectedIngredient = _selectedIngredient;
                        }

                    }

                }
                else
                {
                    if (_selectedIngredient != null)
                    {
                        _selectedIngredient = null;
                        _rotatingPicker.Rotate();
                    }
                }
            }
        }
    }
}
