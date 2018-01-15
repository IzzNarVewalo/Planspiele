using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeToUI : MonoBehaviour {
    public Text leftSide, rightSide;
    
    private void Update()
    {
      /*  if (Input.GetKeyDown(KeyCode.O))
        {
            List<Ingredient> temp = new List<Ingredient>();
            temp.Add(new Ingredient(0.5f,Unit.Cup, Ingredients.Coffe, null));
            temp.Add(new Ingredient(2f, Unit.Tablespoon, Ingredients.Cherries, null));
            temp.Add(new Ingredient(500f, Unit.Ml, Ingredients.Milk, null));
            writeRecipe(temp);
        }*/

        

    }

    public void writeRecipe(List<Ingredient> ingredients)
    {
        leftSide.text = "";
        rightSide.text = "";
        foreach(Ingredient i in ingredients)
        {
            leftSide.text = leftSide.text + makeAmountNice(i) + " " + i.getUnit() + "\n";
            rightSide.text = rightSide.text + i.getName() + "\n";
        }
        leftSide.text += "Serve!";

    }

    private string makeAmountNice(Ingredient i)
    {
        Debug.Log("Meow"+ i.getUnit());
        if (i.getUnit().Equals("Cup"))
        {
            Debug.Log("Woof"+i.getAmount());
            if(i.getAmount() == 0.5f)
            {
                Debug.Log("Peep");
                return "1/2";
            }else if(i.getAmount() == 0.33f)
            {
                return "1/3";
            }else if(i.getAmount() == 0.2f)
            {
                return "1/4";
            }
            else
            {
                return "" + i.getAmount();
            }
        }
        else
        {
            return "" + i.getAmount();
        }
    }

}
