using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeManager : MonoBehaviour {
    // Collection of all available recipes
    private List<Recipe> recipes;

    // The recipe that is currently selected and made
    private Recipe activeRecipe;

    void Start()
    {
        recipes = new List<Recipe>();
        recipes.Add(new Recipe("Demo Recipe",
            0,
            new List<Ingredient>(
                new Ingredient[] {
                    new Ingredient(1, Unit.Cup, Ingredients.Cup),
                    new Ingredient(100, Unit.Ml, Ingredients.Coffe),
                    new Ingredient(50, Unit.Ml, Ingredients.Milk) })));

        activeRecipe = recipes[0];
        activeRecipe.Begin();
    }

    void Update()
    {
        if(activeRecipe != null)
        {
            activeRecipe.Update();
        }
    }

    

    /*public GameObject player;

    int stepCounter = 0;
    float menuRotData = 0;
    bool gotMenuUpdate = false, waitForRotData = false;

    CupMovement cm;

    //User Coffee Data

    string cupSize, spicePickedUp, spice;
    float amountOfCoffee;
    float amountOfMilk;


	// Use this for initialization
	void Start () {
        cm = player.GetComponent<CupMovement>();
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("Stepcounter: " + stepCounter);

        if(waitForRotData)
        {
            waitForMenuInput();
        }

    }

    public void fillCup(string ingrediant,float amount)
    {
        if(stepCounter == 2&&ingrediant.Equals("coffee"))
        {
            Debug.Log("Cup has " + (amount * 100) + "% coffee");
            amountOfCoffee = amount;
            stepCounter++;
        }else if(stepCounter == 5 && ingrediant.Equals("milk"))
        {
            Debug.Log("Cup has " + (amount * 100) + "% milk");
            amountOfMilk = amount;
            stepCounter++;
        }else if(stepCounter == 9&&ingrediant.Equals("spice"))
        {
            Debug.Log("Cup has " + spicePickedUp);
            spice = ingrediant;            
        }

    }

    public void cupSatDown()
    {
        if(stepCounter == 3)
        {
            //Finished  pouring coffee 

            cm.spawnIngrediant("milk");

            stepCounter++;
            Debug.Log("Switch to milk scene");


        }else if(stepCounter == 6)
        {
            //Finished adding milk

            cm.spawnIngrediant("spice");
            stepCounter++;
            Debug.Log("Switch to spice Scene");
        }
    }

    public void cupPickedUp()
    {
        if (stepCounter == 0)
        {
            //Pickup the cup for the first time / start the game
            stepCounter++;
            openChooseMenu();
            Debug.Log("Open Size-Choose-Menu");
        }else if (stepCounter == 4)
        {
            //Pickup Milk
            cm.movementLocked = false;
            stepCounter++;
            Debug.Log("Picked up milk");
        }else if(stepCounter == 7)
        {
            openChooseMenu();
            stepCounter++;
            Debug.Log("Open Spice Menu");

        }
    }

    public void openChooseMenu()
    {
        //TODO: Open Menu
        cm.inMenu = true;
        cm.movementLocked = true;
        waitForRotData = true;
    }

    public void setRotData(float rot)
    {
        menuRotData = rot;
        gotMenuUpdate = true;
    }

    void waitForMenuInput()
    {

        //Get Rot data at squeeze
        if (gotMenuUpdate && stepCounter == 1)
        {

            if (menuRotData >= 25 && menuRotData < 75)
            {
                cupSize = "small";
                Debug.Log("small");
            }
            else if ((menuRotData >= 0 && menuRotData < 25) || (menuRotData > 335))
            {
                cupSize = "medium";
                Debug.Log("medium");
            }
            else if (menuRotData <= 335 && menuRotData > 285)
            {
                cupSize = "large";
                Debug.Log("large");
            }

            //TODO: Close Menu

            cm.movementLocked = false;
            cm.inMenu = false;
            waitForRotData = false;
            gotMenuUpdate = false;
            stepCounter++;
            Debug.Log("Chose Size");
            
        }
        else if (gotMenuUpdate && stepCounter == 8)
        {
            if (menuRotData >= 25 && menuRotData < 75)
            {
                spicePickedUp = "sugar";
                Debug.Log("Sugar added");
            }
            else if ((menuRotData >= 0 && menuRotData < 25) || (menuRotData > 335))
            {
                spicePickedUp = "cinnamon";
                Debug.Log("Cinnamon added");
            }
            else if (menuRotData <= 335 && menuRotData > 285)
            {
                spicePickedUp = "caramel";
                Debug.Log("Caramel added");
            }
            //TODO: Close Menu
            
            cm.movementLocked = false;
            cm.inMenu = false;
            waitForRotData = false;
            gotMenuUpdate = false;
            stepCounter++;
            Debug.Log("Chose spice");
        }
    }*/

}
