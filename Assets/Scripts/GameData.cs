using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData {

    public static int score = 0;
    public static int penalty = 50;
	public static Ingredient SelectedIngredient { get; set; }

    private static List<Ingredient> AddedIngredients;

    public static Penalty Penalty;

    public static void AddIngredient(Ingredient i)
    {
        AddedIngredients.Add(i);
    }

    public static void Reset()
    {
        SelectedIngredient = null;
        AddedIngredients.Clear();
        Penalty = null;
        score = 0;
    }

}
