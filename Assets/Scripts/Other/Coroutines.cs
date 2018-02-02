using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coroutines : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void AnimatePosition(GameObject target, Vector3 destination, MonoBehaviour caller)
    {
        caller.StartCoroutine(Animate(target, destination));
    }

    private static IEnumerator Animate(GameObject target, Vector3 destination, float speed = 5)
    {
        

        yield break;
    }
}
