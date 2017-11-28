using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class ShareAction : MonoBehaviour {

    protected Text debugText;
    // Is the current Action active?
    protected bool _active;
    // Instruction text which can be shown in the progress list on the UI
    protected string _instruction;

    /// <summary>
    /// When overriding this method, call base.Awake();
    /// </summary>
    protected void Awake()
    {
        debugText = GameObject.Find("DebugText").GetComponent<Text>();
        if(debugText == null)
        {
            Debug.LogError("Debug Text nicht gefunden.");
        }
    }

    public void SetActive(bool active)
    {
        _active = active;
    }

    /// <summary>
    /// If the action is finished, this returns true.
    /// </summary>
    /// <returns>True, if finished</returns>
    public abstract bool Finished();

    /// <summary>
    /// To make the Actions work, they need to be added to a GameObject.
    /// Every Child Class needs to instantiate itself by first creating a GameObject g and then return g.AddComponent
    /// See ActionSelectCup.cs for Example.
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
        Debug.Log("Exiting Action " + GetType());
        _active = true;
    }

    /// <summary>
    /// This is called when an Action is finished.
    /// If you override this method, make sure to set _active to false or call the parent method, too.
    /// </summary>
    public virtual void ExitAction()
    {
        _active = false;
    }
	
}