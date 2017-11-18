using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupMovement : MonoBehaviour {

    float valueX;
    float valueY;

    bool pickedUp = false, waitForMouseButtonJumping = false;

    public float speed;
    public bool movementLocked = false, inMenu = false;

    public GameObject recipeHandler;

    RecipeManager rm;
    FillInCoffeZoneTrigger ftc;
    FillInCoffeZoneTrigger ftm;
    FillInCoffeZoneTrigger fts;
    CameraMovement camM;

    Vector3 milkSpawnpoint, spiceSpawnpoint;

    // Use this for initialization
    void Start()
    {
        rm = recipeHandler.GetComponent<RecipeManager>();
        ftc= GameObject.FindGameObjectsWithTag("FillInCoffeeZone")[0].GetComponent<FillInCoffeZoneTrigger>();
        ftm = GameObject.FindGameObjectsWithTag("FillInMilkZone")[0].GetComponent<FillInCoffeZoneTrigger>();
        fts = GameObject.FindGameObjectsWithTag("FillInSpiceZone")[0].GetComponent<FillInCoffeZoneTrigger>();
        camM = GameObject.FindGameObjectsWithTag("MainCamera")[0].GetComponent<CameraMovement>();
        milkSpawnpoint = GameObject.FindGameObjectsWithTag("MilkSpawnpoint")[0].transform.position;
        spiceSpawnpoint = GameObject.FindGameObjectsWithTag("SpiceSpawnpoint")[0].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (pickedUp)
        {

            transform.Rotate(Input.GetAxis("Horizontal") * Time.deltaTime * speed, 0, Input.GetAxis("Vertical") * Time.deltaTime * speed);
           // Debug.Log("Horizontal: " + Input.GetAxis("Horizontal"));
           // Debug.Log("Vertical: " + Input.GetAxis("Vertical"));

            if (!movementLocked)
            {
                transform.Translate(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0, Space.World);
            }

        }

        if (Input.GetMouseButton(0)&&!waitForMouseButtonJumping)
        {
            if (pickedUp)
            {
                rm.cupSatDown();
            }
            else
            {
                Debug.Log("PickedUp");
                rm.cupPickedUp();
            }

            pickedUp = !pickedUp;
            StartCoroutine("mouseButtonDelay");
            Debug.Log("Meow");
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("inMilkZone: " + ftm.getInMilkZone());

            if (inMenu)
            {
                Debug.Log("Z-Rotation: " + transform.rotation.eulerAngles.z);
                rm.setRotData(transform.rotation.eulerAngles.z);
            }else if (ftc.getInCoffeeZone())
            {
                //TODO: Amount depending on how long you squeeze
                Debug.Log("FillInCoffee");
                rm.fillCup("coffee", 0.5f);
            }else if (ftm.getInMilkZone())
            {
                Debug.Log("FillInMilk");
                rm.fillCup("milk", 0.25f);
            }else if (fts.getInSpiceZone())
            {
                Debug.Log("FillInSpice");
                rm.fillCup("spice", 0);
            }

        }

    }

    IEnumerator mouseButtonDelay()
    {
        waitForMouseButtonJumping = true;
        yield return new WaitForSeconds(0.1f);
        waitForMouseButtonJumping = false;

    }

    public void spawnIngrediant(string ingrediant)
    {

        if (ingrediant.Equals("milk"))
        {
            transform.position = milkSpawnpoint;
            camM.switchPosition();
        }else if (ingrediant.Equals("spice"))
        {
            transform.position = spiceSpawnpoint;
            camM.switchPosition();
        }
        

    }

}
