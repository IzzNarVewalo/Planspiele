using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        float coffeeCupOffset = 0;
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        if (meshFilter != null)
        {
            coffeeCupOffset = meshFilter.mesh.bounds.min.y;
            Debug.Log(coffeeCupOffset);
            Debug.Log(meshFilter.mesh.bounds.size.y);
            transform.position = transform.position + new Vector3(0, coffeeCupOffset, 0);
        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
