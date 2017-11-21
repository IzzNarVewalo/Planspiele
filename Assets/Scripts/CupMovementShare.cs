using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CupMovementShare : MonoBehaviour {

    float valueX;
    float valueY;

    bool pickedUp = false, waitForMouseButtonJumping = false;

    public float speed;
    public bool movementLocked = false, inMenu = false;

    public float ldrThreshold;
    private float ldrSmoothed;
    public float forceThreshold;


    public GameObject recipeHandler;

    public UnityEvent onPickup;

    RecipeManager rm;
    FillInCoffeZoneTrigger ftc;
    FillInCoffeZoneTrigger ftm;
    FillInCoffeZoneTrigger fts;
    CameraMovement camM;
    Communication com;

    Vector3 milkSpawnpoint, spiceSpawnpoint;

    // Use this for initialization
    void Start()
    {
        rm = recipeHandler.GetComponent<RecipeManager>();
        ftc = GameObject.FindGameObjectsWithTag("FillInCoffeeZone")[0].GetComponent<FillInCoffeZoneTrigger>();
        ftm = GameObject.FindGameObjectsWithTag("FillInMilkZone")[0].GetComponent<FillInCoffeZoneTrigger>();
        fts = GameObject.FindGameObjectsWithTag("FillInSpiceZone")[0].GetComponent<FillInCoffeZoneTrigger>();
        camM = GameObject.FindGameObjectsWithTag("MainCamera")[0].GetComponent<CameraMovement>();
        com = GameObject.FindGameObjectsWithTag("MainCamera")[0].GetComponent<Communication>();
        milkSpawnpoint = GameObject.FindGameObjectsWithTag("MilkSpawnpoint")[0].transform.position;
        spiceSpawnpoint = GameObject.FindGameObjectsWithTag("SpiceSpawnpoint")[0].transform.position;
        onPickup.AddListener(new UnityAction(OnPickup));
    }

    private void OnPickup()
    {
        Debug.Log("[Event] Picked up!");
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("LDR: " + com.ldr);
        //Debug.Log("Force: " + com.force);

        Debug.Log("PickedUp: " + pickedUp);



        checkLdr();


        if (pickedUp)
        {
            transform.localRotation = com.rotQuat;
            
            if (!movementLocked)
            {
                //transform.Translate(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0, Space.World);
            }

        }

        if (!waitForMouseButtonJumping)
        {
            if (pickedUp)
            {
                rm.cupPickedUp();
            }
            else
            {
                Debug.Log("PickedUp");
                rm.cupSatDown();
            }

           // pickedUp = !pickedUp;
            StartCoroutine("mouseButtonDelay");
        }


        if (com.force > forceThreshold)
        {
            Debug.Log("Squeeze");

            if (inMenu)
            {
                Debug.Log("Z-Rotation: " + transform.rotation.eulerAngles.z);
                rm.setRotData(transform.rotation.eulerAngles.z);
            }
            else if (ftc.getInCoffeeZone())
            {
                //TODO: Amount depending on how long you squeeze
                Debug.Log("FillInCoffee");
                rm.fillCup("coffee", 0.5f);
            }
            else if (ftm.getInMilkZone())
            {
                Debug.Log("FillInMilk");
                rm.fillCup("milk", 0.25f);
            }
            else if (fts.getInSpiceZone())
            {
                Debug.Log("FillInSpice");
                rm.fillCup("spice", 0);
            }

        }

    }

    private void checkLdr()
    {
        ldrSmoothed = (ldrSmoothed + com.ldr) / 2;
        if (ldrSmoothed < ldrThreshold)
        {
            if (!pickedUp)
                onPickup.Invoke();// Vector3.Angle(Vector3.up, com.RawAcceleration));

            pickedUp = true;
        }
        else
        {
            pickedUp = false;
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
        }
        else if (ingrediant.Equals("spice"))
        {
            transform.position = spiceSpawnpoint;
            camM.switchPosition();
        }


    }

}
