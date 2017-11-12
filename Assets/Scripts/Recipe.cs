using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe {

    private String _name;
    private int _id;
    private List<Ingredient> _ingredients;

    public Recipe(String name, int id,  List<Ingredient> ingredients) {
        _name = name;
        _id = id;
        _ingredients = ingredients;
    }

    public void AddIngredient(Ingredient ingredient) {
        _ingredients.Add(ingredient);
    }

    public String GetName() {
        return _name;
    }

    public String GetIngredients() {
        String ingr = null;
        foreach (Ingredient ingredient in _ingredients) {
            ingr += ingredient.PrintIngredient() + "\n";
        }
        return ingr;
    }
}
