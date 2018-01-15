using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData {

	public static Ingredient SelectedIngredient { get; set; }

    private static List<Ingredient> AddedIngredients;

    public static void AddIngredient(Ingredient i)
    {
        AddedIngredients.Add(i);
    }

    public static void Reset()
    {
        SelectedIngredient = null;
        AddedIngredients.Clear();
    }

}
