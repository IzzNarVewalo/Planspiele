using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MugMovement : MonoBehaviour {
   
    float valueX;
    float valueY;
    public float speed;
     
    // Use this for initialization
    void Start () {
        

	}
	
	// Update is called once per frame
	void Update () {
        valueX = Input.GetAxis("Mouse X");
        Debug.Log(valueX);
        valueY = Input.GetAxis("Mouse Y");


   //[-0.05 ; 0.05]]
   // transform.Rotate(Vector3.right * Time.deltaTime);
        transform.Rotate(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0);
        transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * Time.deltaTime*speed, Input.GetAxisRaw("Vertical") * Time.deltaTime*speed, 0), Space.World);

        if (Input.GetMouseButton(0))
        {
            Debug.Log("Meow");
        }



        //transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, 0);
        //transform.Rotate(Vector3.right,valueY * Time.deltaTime*speed);





    }

	}

