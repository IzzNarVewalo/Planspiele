using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillInCoffeZoneTrigger : MonoBehaviour {

    public bool inFillInCoffeeZone = false;

    void OnTriggerEnter(Collider c)
    {

        if (c.gameObject.tag == "Player")
        {

            Debug.Log("Triggered !!!!!!!");            

            inFillInCoffeeZone = true;
        }

    }

    void OnTriggerExit(Collider c)
    {
        //Debug.Log("Triggered !!!!!!");
        if (c.gameObject.tag == "Player")
        {
            Debug.Log("Calmed down *sigh* ");
            inFillInCoffeeZone = false;
        }

    }
}
