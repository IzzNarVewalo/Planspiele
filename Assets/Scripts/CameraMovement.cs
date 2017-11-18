using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public List<GameObject> cameraPositions;
    public float speed = 10;

    int positionCounter = 0;
    bool moveToNextPos = false;


	// Update is called once per frame
	void Update () {

        if (moveToNextPos)
        {
            
            transform.position = Vector3.Lerp(transform.position, cameraPositions[positionCounter].transform.position, speed);
            
            if((transform.position.x - cameraPositions[positionCounter].transform.position.x) < 0.1f)
            {
                moveToNextPos = false;
            }

        }
        
	}

    public void switchPosition()
    {
        positionCounter = (positionCounter+1)%cameraPositions.Count;
        moveToNextPos = true;
    }

}
