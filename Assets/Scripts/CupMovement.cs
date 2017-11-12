using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupMovement : MonoBehaviour {

    float valueX;
    float valueY;
    public float speed;

    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Input.GetAxis("Horizontal")*Time.deltaTime*speed, 0 ,Input.GetAxis("Vertical")*Time.deltaTime*speed);
        Debug.Log("Horizontal: " + Input.GetAxis("Horizontal"));
        Debug.Log("Vertical: " + Input.GetAxis("Vertical"));

        transform.Translate(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0, Space.World);
        if (Input.GetMouseButton(0))
        {
            Debug.Log("Meow");
        }
    }
}
