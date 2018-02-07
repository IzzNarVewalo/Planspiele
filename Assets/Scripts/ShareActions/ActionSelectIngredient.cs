using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionSelectIngredient : ShareAction
{

    private bool _ingredientIsSelected = false;

    private bool _lock = false;

    private Ingredient _selectedIngredient = null;

    private IShareInput _shareInput;

    private RotatingPicker _rotatingPicker;
    private IngredientPicker _picker;
    private CupMovement _cupMovement;

    private static string _rotatingPickerName = "PlateHolder";

    public override bool Finished()
    {
        return _ingredientIsSelected;
    }


    protected override void SetInstructionImages()
    {
        instructionImages = new Sprite[2];
        instructionImages[0] = Resources.Load<Sprite>("Take1");
        instructionImages[1] = Resources.Load<Sprite>("Take2");
    }

    public override void EnterAction()
    {
        base.EnterAction();
        ShowInstructionText("Pick up the cup to stop the rotation and select the ingredient.");
        _shareInput = ShareInputManager.ShareInput;
        _active = true;
        GameObject rotatingPickerObject = GameObject.Find(_rotatingPickerName);
        if(rotatingPickerObject != null)
            _rotatingPicker = rotatingPickerObject.GetComponentInChildren<RotatingPicker>();
        _picker = FindObjectOfType<IngredientPicker>();
        _cupMovement = FindObjectOfType<CupMovement>();
        
        if(_picker != null && _cupMovement != null)
        {
            _picker.SetupIngredients();
            _picker.Rotate();

            Vector3 playerPosition = _cupMovement.transform.position;
            playerPosition.x = _picker.transform.position.x - 7f;
            _cupMovement.transform.position = playerPosition;

            Vector3 cameraAnimatePosition = Camera.main.transform.position;
            cameraAnimatePosition.x = _picker.transform.position.x - 3.5f;
            Coroutines.AnimatePosition(Camera.main.gameObject, cameraAnimatePosition, this);
            

        } else
        {
            Debug.LogError("Couldn't find IngredientPicker or CupMovement!");
        }
        
    }

    public override void ExitAction()
    {
        base.ExitAction();
    }

    // Use this for initialization
    void Start()
    {

    }

    private void OnIngredientPutDown()
    {
        _picker.Rotate();
        _lock = false;
    }

    private void OnIngredientPickedUp()
    {
        Debug.Log("Unlocked");
        _lock = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_active && !_lock)
        {
            base.Update();
            if (_picker != null)
            {
                if (_shareInput.IsPickedUp())
                {
                    if (_selectedIngredient == null)
                    {
                        SoundEffectManager.Instance.PlayLiftCup();
                        _selectedIngredient = _picker.Select();
                        if(_selectedIngredient == null)
                        {
                            Debug.LogError("Selected ingredient null");
                        }
                        _lock = true;
                        _cupMovement.PickUpObject(_selectedIngredient.gameObject, OnIngredientPickedUp);
                        
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
                        if (ReferenceEquals(GameData.SelectedIngredient, null))
                        {
                            GameData.SelectedIngredient = _selectedIngredient;
                        }

                    }

                }
                else
                {
                    if (_selectedIngredient != null)
                    {
                        _lock = true;
                        _cupMovement.PutDownObject(OnIngredientPutDown);

                        _selectedIngredient = null;
                    }
                }
            }
        }
    }
}
