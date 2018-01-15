using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe {

    private String _name;
    private int _id;
    private Size _size;
    private List<Ingredient> _ingredients;
    private List<ShareAction> _actions;
    private int _activeActionIndex = 0;
    private ShareAction _activeAction;

    public Recipe(String name, int id, Size size,  List<Ingredient> ingredients) {
        _name = name;
        _id = id;
        _size = size;
        _ingredients = ingredients;

        _actions = new List<ShareAction>();
    }

    public void Begin()
    {
        foreach (Ingredient ingredient in _ingredients)
        {
            if(ingredient.GetShareActions() != null)
                _actions.AddRange(ingredient.GetShareActions());
        }

        _activeAction = _actions[0];
        _activeAction.EnterAction();
    }

    public void Update()
    {
        if (_activeAction != null && _activeAction.Finished())
        {
            _activeAction.ExitAction();
            _actions.RemoveAt(0);
            if(_actions.Count > 0)
            {
                _activeAction = _actions[0];
                _activeAction.EnterAction();
            } else
            {
                _activeAction = null;
            }
        }
    }

    public bool Finished()
    {
        return _actions.Count == 0;
    }

    public void AddIngredient(Ingredient ingredient) {
        _ingredients.Add(ingredient);
        _actions.AddRange(ingredient.GetShareActions());
    }

    public String GetName() {
        return _name;
    }
    public String GetSize()
    {
        return _size.ToString();
    }

    public String GetIngredients() {
        String ingr = null;
        foreach (Ingredient ingredient in _ingredients) {
            ingr += ingredient.PrintIngredient() + "\n";
        }
        return ingr;
    }
    public List<Ingredient> GetIngredientsList()
    {
        return _ingredients;
    }
}
