using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeToUI : MonoBehaviour {
    public Text leftSide, rightSide, headline;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            List<Ingredient> temp = new List<Ingredient>();
            temp.Add(new Ingredient(0.5f,Unit.Cup, Ingredients.Coffe, null));
            temp.Add(new Ingredient(2f, Unit.Tablespoon, Ingredients.Cherries, null));
            temp.Add(new Ingredient(500f, Unit.Ml, Ingredients.Milk, null));
            temp[2].SetProgress(1f);
            temp[1].SetProgress(1f);
            Recipe r = new Recipe("Cherry-Latte", 0, Size.Big, temp);
            writeRecipe(r);
        }
    }

    //Writes the Recipe on the Note
    public void writeRecipe(Recipe recipe)
    {
        //Reset textboxes
        leftSide.text = "";
        rightSide.text = "";
        //Write out the Recipename
        headline.text = recipe.GetSize() + " "+recipe.GetName();
        List<Ingredient> ingredients = recipe.GetIngredientsList();

        //Write out the Ingredients
        foreach(Ingredient i in ingredients)
        {
            string left = "";
            string right = "";
            left =makeAmountNice(i) + " " + i.GetUnit();
            right = right + i.GetName();
            //Sets the checkmark and changes color to green if the ingredient is finished
            if (i.GetProgress() >= 1f)
            {
                /*left = StrikeThrough(left);
                right = StrikeThrough(right);*/
                left = '\u2713'+left;
                left = "<color=#008000ff>" + left + "</color>";
                right = "<color=#008000ff>" + right + "</color>";
            }
            else
            {
                left = "    "+left;     //Makes the format prettier
            }
            leftSide.text += left+"\n";
            rightSide.text += right+"\n";
        }
        leftSide.text += "    Serve!";
    }

    //Can be used to make strikethrough text
    private string StrikeThrough(string s)
    {
        string strikethrough = "";
        foreach (char c in s)
        {
            strikethrough = strikethrough + c + '\u0336';
        }
        return strikethrough;
    }

    //Changes Cupsizes to fractions, just looks prettier
    private string makeAmountNice(Ingredient i)
    {
        if (i.GetUnit().Equals("Cup"))
        {
            if(i.GetAmount() == 0.5f)
            {
                return "1/2";
            }else if(i.GetAmount() == 0.33f)
            {
                return "1/3";
            }else if(i.GetAmount() == 0.2f)
            {
                return "1/4";
            }
            else
            {
                return "" + i.GetAmount();
            }
        }
        else
        {
            return "" + i.GetAmount();
        }
    }

}
