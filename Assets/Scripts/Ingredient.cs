using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient {
    public static Dictionary<Ingredients, string> IngredientToString;
    public static Dictionary<Unit, string> UnitToString;

    public static void Translate() {
        IngredientToString = new Dictionary<Ingredients, string>();
        UnitToString = new Dictionary<Unit, string>();
        IngredientToString.Add(Ingredients.Apples, "Apples");
        IngredientToString.Add(Ingredients.Cocoa, "Cocoa");
        IngredientToString.Add(Ingredients.Cherries, "Cherries");
        IngredientToString.Add(Ingredients.Coffe, "Coffe");
        IngredientToString.Add(Ingredients.LemonJuice, "Lemon juice");
        IngredientToString.Add(Ingredients.Milk, "Milk");
        IngredientToString.Add(Ingredients.Oranges, "Oranges");
        IngredientToString.Add(Ingredients.Raspberries, "Raspberries");
        IngredientToString.Add(Ingredients.Sugar, "Sugar");
        IngredientToString.Add(Ingredients.WhippedCream, "whipped Cream");

        UnitToString.Add(Unit.Cl, " cl ");
        UnitToString.Add(Unit.Cup, " cup ");
        UnitToString.Add(Unit.Ml, " ml ");
        UnitToString.Add(Unit.Tablespoon, " Tablespoon ");
    }

    private float _amount;
    private Unit _unit;
    private Ingredients _name;

    public Ingredient(float amount, Unit unit, Ingredients name) {
        _amount = amount;
        _unit = unit;
        _name = name;
    }

    public String PrintIngredient() {
        return _amount + UnitToString[_unit] + IngredientToString[_name];
    }
}   