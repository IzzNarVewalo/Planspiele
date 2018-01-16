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

    public void writeRecipe(Recipe recipe)
    {
        leftSide.text = "";
        rightSide.text = "";
        headline.text = recipe.GetSize() + " "+recipe.GetName();
        List<Ingredient> ingredients = recipe.GetIngredientsList();

        foreach(Ingredient i in ingredients)
        {
            string left = "";
            string right = "";
            left =makeAmountNice(i) + " " + i.GetUnit();
            right = right + i.GetName();
            if(i.GetProgress() >= 1f)
            {
                /*left = StrikeThrough(left);
                right = StrikeThrough(right);*/
                left = '\u2713'+left;
            }
            else
            {
                left = "    "+left; 
            }
            leftSide.text += left+"\n";
            rightSide.text += right+"\n";
        }
        leftSide.text += "    Serve!";
    }
    private string StrikeThrough(string s)
    {
        string strikethrough = "";
        foreach (char c in s)
        {
            strikethrough = strikethrough + c + '\u0336';
        }
        return strikethrough;
    }

    private string makeAmountNice(Ingredient i)
    {
        Debug.Log("Meow"+ i.GetUnit());
        if (i.GetUnit().Equals("Cup"))
        {
            Debug.Log("Woof"+i.GetAmount());
            if(i.GetAmount() == 0.5f)
            {
                Debug.Log("Peep");
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
