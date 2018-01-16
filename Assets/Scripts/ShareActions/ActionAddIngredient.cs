using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActionAddIngredient : ShareAction {

    protected void UpdateIngredientProgress(float progress)
    {
        if (GameData.SelectedIngredient != null)
        {
            GameData.SelectedIngredient.SetProgress(progress);
        }
    }

}
