using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActionAddIngredient : ShareAction {

    protected void UpdateIngredientProgress(float progress)
    {
        if (!ReferenceEquals(GameData.SelectedIngredient, null))
        {
            GameData.SelectedIngredient.SetProgress(progress);
        } else
        {
            Debug.LogError("Ingredient not selected!");
        }

        ProgressBarScript.value = progress;
    }

    public override void ExitAction()
    {
        base.ExitAction();
        if (!ReferenceEquals(GameData.SelectedIngredient, null) && GameData.SelectedIngredient.GetProgress() < 1.0f)
            GameData.SelectedIngredient.SetProgress(2.0f - GameData.SelectedIngredient.GetProgress());
    }

}
