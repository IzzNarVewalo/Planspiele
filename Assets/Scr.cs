using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        /*float coffeeCupOffset = 0;
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        BoxCollider boxCollider = GetComponent<BoxCollider>();
        /*if (meshFilter != null)
        {
            coffeeCupOffset = meshFilter.mesh.bounds.min.y;
            Debug.Log(coffeeCupOffset);
            Debug.Log(meshFilter.mesh.bounds.size.y);
            transform.position = transform.position + new Vector3(0, coffeeCupOffset, 0);
        }*/
        /*if(meshFilter != null)
        {
            transform.Translate(Vector3.up * meshFilter.mesh.bounds.extents.y * transform.localScale.y);
        }*/

        Coroutines.AnimatePosition(gameObject, transform.position, this, true);
    }

	// Update is called once per frame
	void Update () {
		
	}
}
