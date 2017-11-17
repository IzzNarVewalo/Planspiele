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
    FillInCoffeZoneTrigger ft;

    // Use this for initialization
    void Start()
    {
        rm = recipeHandler.GetComponent<RecipeManager>();
        ft= GameObject.FindGameObjectsWithTag("FillInCoffeeZone")[0].GetComponent<FillInCoffeZoneTrigger>();
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
            if (inMenu)
            {
                Debug.Log("Z-Rotation: " + transform.rotation.eulerAngles.z);
                rm.setRotData(transform.rotation.eulerAngles.z);
            }else if (ft.inFillInCoffeeZone)
            {
                //TODO: Amount depending on how long you squeeze
                Debug.Log("InZone!!!");
                rm.fillCup("coffee", 0.5f);

            }

        }

    }

    IEnumerator mouseButtonDelay()
    {
        waitForMouseButtonJumping = true;
        yield return new WaitForSeconds(0.1f);
        waitForMouseButtonJumping = false;

    }

}
