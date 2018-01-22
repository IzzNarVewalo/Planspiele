﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient {
    public static Dictionary<Ingredients, string> IngredientToString;
    public static Dictionary<Unit, string> UnitToString;
    // Includes the actions for each Ingredient that need to be fulfilled to add the ingredient
    public static Dictionary<Ingredients, ShareAction[]> IngredientActions;

    private List<ShareAction> _actions;
    private float _amount;
    private Unit _unit;
    private Ingredients _name;
    private float _progress = 0;
    
    private static Dictionary<Unit, object> _meshForIngredient;

    //static Ingredient()
    //{
    //    SetupIngredientActions();
    //}

    public static void Translate() {
        IngredientToString = new Dictionary<Ingredients, string>();
        UnitToString = new Dictionary<Unit, string>();
        IngredientToString.Add(Ingredients.Apple, Translation.Get("Apple"));
        IngredientToString.Add(Ingredients.Cocoa, Translation.Get("Cocoa"));
        IngredientToString.Add(Ingredients.Caramel, Translation.Get("Caramel"));
        IngredientToString.Add(Ingredients.Cherry, Translation.Get("Cherry"));
        IngredientToString.Add(Ingredients.Coffee, Translation.Get("Coffee"));
        IngredientToString.Add(Ingredients.LemonJuice, Translation.Get("LemonJuice"));
        IngredientToString.Add(Ingredients.Milk, Translation.Get("Milk"));
        IngredientToString.Add(Ingredients.Orange, Translation.Get("Orange"));
        IngredientToString.Add(Ingredients.Raspberry, Translation.Get("Raspberry"));
        IngredientToString.Add(Ingredients.Sugar, Translation.Get("Sugar"));
        IngredientToString.Add(Ingredients.WhippedCream, Translation.Get("WhippedCream"));
        IngredientToString.Add(Ingredients.SmallCup, Translation.Get("SmallCup"));
        IngredientToString.Add(Ingredients.MediumCup, Translation.Get("MediumCup"));
        IngredientToString.Add(Ingredients.LargeCup, Translation.Get("LargeCup"));


        UnitToString.Add(Unit.Cl, Translation.Get("Ml"));
        UnitToString.Add(Unit.Cup, Translation.Get("Cup"));
        UnitToString.Add(Unit.Ml, Translation.Get("Ml"));
        UnitToString.Add(Unit.Tablespoon, Translation.Get("Tablespoon"));
    }

    public Ingredient(float amount, Unit unit, Ingredients name, List<ShareAction> actions) {
        _amount = amount;
        _unit = unit;
        _name = name;
        _actions = actions;
    }

    public String PrintIngredient() {
        return _amount + UnitToString[_unit] + IngredientToString[_name];
    }

    public float GetAmount()
    {
        return _amount;
    }
    public String GetUnit()
    {
        Translate();
        return UnitToString[_unit];
    }
    public String GetName()
    {
        return IngredientToString[_name];
    }
    public float GetProgress()
    {
        return _progress;
    }
    public void SetProgress(float progress)
    {
        float oldProgress = _progress;
        _progress = progress;
        if (oldProgress < 1 && progress >= 1)
        {
            RecipeManager.UpdateRecipeUI();
            SoundEffectManager.Instance.PlaySubtaskComplete();
        }
    }

    public List<ShareAction> GetShareActions()
    {
            return _actions;
    }

    public object GetMeshForIngredient(Unit u) {
        return _meshForIngredient[u];
    }

    public void AddMeshForIngredient(Unit key, object value) {
        _meshForIngredient.Add(key, value);
    }

    public object GetMesh() {
        return _meshForIngredient[_unit];
    }
}   