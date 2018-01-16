using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class ShareAction : MonoBehaviour {

    // Is the current Action active?
    protected bool _active;
    // Instruction text which can be shown in the progress list on the UI
    protected string _instruction;
    protected static Text _instructionText;
    // The name of the GameObject which should be used as the Text _instructionText
    protected static string _instructionTextObjectName = "DebugText";

    protected static RecipeToUI _recipeToUI;

    /// <summary>
    /// When overriding this method, call base.Awake();
    /// </summary>
    protected void Awake()
    {
        
        if(_instructionText == null)
        {
            _instructionText = GameObject.Find(_instructionTextObjectName).GetComponent<Text>();
        }

        if(_recipeToUI == null)
        {
            _recipeToUI = FindObjectOfType<RecipeToUI>();
        }
    }

    public void SetActive(bool active)
    {
        _active = active;
    }

    protected void ShowInstructionText(string instruction)
    {
        _instruction = instruction;
        ShowInstructionText();
    }

    protected void ShowInstructionText()
    {
        if(_instructionText != null)
        {
            _instructionText.text = _instruction;
        } else
        {
            Debug.LogError("Text _instructionText is not set in ShareAction.");
        }
    }

    /// <summary>
    /// If the action is finished, this returns true.
    /// </summary>
    /// <returns>True, if finished</returns>
    public abstract bool Finished();

    /// <summary>
    /// To make the Actions work, they need to be added to a GameObject.
    /// If they are not created using this method, every Child Class needs to instantiate itself by first creating a GameObject g and then return g.AddComponent();
    /// </summary>
    /// <returns></returns>
    public static ShareAction Create<T>() where T : ShareAction {
        GameObject g = new GameObject();
        return g.AddComponent<T>();
    }

    /// <summary>
    /// This is called when an Action is starting. 
    /// If you override this method, make sure to set _active to true, or call the parent method, too.
    /// You can do all the setup you need for the action here.
    /// </summary>
    public virtual void EnterAction() {
        Debug.Log("Enter Action " + GetType());
        _active = true;
    }

    /// <summary>
    /// This is called when an Action is finished.
    /// If you override this method, make sure to set _active to false or call the parent method, too.
    /// </summary>
    public virtual void ExitAction()
    {
        Debug.Log("Exit Action " + GetType());
        _active = false;
    }
	
}