using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient {
    public static Dictionary<Ingredients, string> IngredientToString;
    public static Dictionary<Unit, string> UnitToString;
    // Includes the actions for each Ingredient that need to be fulfilled to add the ingredient
    public static Dictionary<Ingredients, ShareAction[]> IngredientActions;

    static Ingredient()
    {
        SetupIngredientActions();
    }

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
        IngredientToString.Add(Ingredients.Cup, "Normal Size Cup");


        UnitToString.Add(Unit.Cl, " cl ");
        UnitToString.Add(Unit.Cup, " cup ");
        UnitToString.Add(Unit.Ml, " ml ");
        UnitToString.Add(Unit.Tablespoon, " Tablespoon ");
    }

    public static void SetupIngredientActions()
    {
        IngredientActions = new Dictionary<Ingredients, ShareAction[]>();

        IngredientActions.Add(Ingredients.Cup, new ShareAction[] {
            ShareAction.Create<ActionSelectCup>()
        });

        IngredientActions.Add(Ingredients.Coffe, new ShareAction[] {
            ActionAddIngredient.Create(new Ingredient(100, Unit.Ml, Ingredients.Coffe))
        });

        IngredientActions.Add(Ingredients.Milk, new ShareAction[] {
            ActionAddIngredient.Create(new Ingredient(100, Unit.Ml, Ingredients.Coffe))
        });
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

    public ShareAction[] GetShareActions()
    {
        switch (_name)
        {

        }
        ShareAction[] actions;
        if (IngredientActions.TryGetValue(_name, out actions))
        {
            return actions;
        }

        return new ShareAction[] { };
    }
}   