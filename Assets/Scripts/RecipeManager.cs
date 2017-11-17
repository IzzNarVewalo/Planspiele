using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeManager : MonoBehaviour {

    public GameObject player;

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
            amountOfMilk = amount;
            stepCounter++;
        }else if(stepCounter == 8)
        {
            spice = ingrediant;            
        }

    }

    public void cupSatDown()
    {
        if(stepCounter == 3)
        {
            //Finished  pouring coffee 

            stepCounter++;
            //TODO: Switch Scene to Ingredient Space & Lock movement
        }else if(stepCounter == 6)
        {
            //Finished adding milk
            stepCounter++;
            //TODO: Switch Scene to Spice Space & Lock movement
        }
    }

    public void cupPickedUp()
    {
        if (stepCounter == 0)
        {
            //Pickup the cup for the first time / start the game
            stepCounter++;
            openChooseMenu();
        }else if (stepCounter == 4)
        {
            //Pickup Milk
            stepCounter++;

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

            if (menuRotData > 25 && menuRotData < 75)
            {
                cupSize = "small";
                Debug.Log("small");
            }
            else if ((menuRotData > 0 && menuRotData < 25) || (menuRotData > 335))
            {
                cupSize = "medium";
                Debug.Log("medium");
            }
            else if (menuRotData < 335 && menuRotData > 285)
            {
                cupSize = "large";
                Debug.Log("large");
            }

            //TODO: Close Menu

            cm.movementLocked = false;
            cm.inMenu = false;
            stepCounter++;
            waitForRotData = false;
        }
        else if (gotMenuUpdate && stepCounter == 7)
        {
            if (menuRotData < -25 && menuRotData > -75)
            {
                spicePickedUp = "sugar";
            }
            else if (menuRotData < 25 && menuRotData > -25)
            {
                spicePickedUp = "cinnamon";
            }
            else if (menuRotData > 25 && menuRotData < 75)
            {
                spicePickedUp = "caramel";
            }
            //TODO: Close Menu
            stepCounter++;
            cm.movementLocked = false;
            cm.inMenu = false;
            waitForRotData = false;
        }
    }

}
