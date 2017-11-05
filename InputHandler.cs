using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour {

    public float speed = 10.0f, rotationSpeed = 100.0f;
    public Material cubeMaterial;

    private Gyroscope gyro;
    private bool toggleColorBool = true;

    void Start()
    {
        gyro = Input.gyro;
        cubeMaterial.color = Color.green;
    }

    // Update is called once per frame
    void Update () {

        if (!gyro.enabled)
        {
            gyro.enabled = true;
        }

        Quaternion rotate = gyro.attitude;

        rotate.x = gyro.attitude.x;
        rotate.y = gyro.attitude.y;
        rotate.z = gyro.attitude.z;

        transform.rotation = rotate;
        


        if (Input.touchCount > 0) { 
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                toggleColor();
            }
            if(Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                toggleColor();
            }
        }

        
		
    }

    void toggleColor()
    {
        if (toggleColorBool)
        {
            cubeMaterial.color = Color.red;
        }
        else
        {
            cubeMaterial.color = Color.green;
        }
        toggleColorBool = !toggleColorBool;
    }

}

