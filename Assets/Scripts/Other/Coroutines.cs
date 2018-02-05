using System;
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

    public static void AnimatePosition(GameObject target, Vector3 destination, MonoBehaviour caller, bool applyBottomOffset = false, Action onFinish = null)
    {
        if (applyBottomOffset)
        {
            destination += Utilities.GetBottomOffset(target);
        }
        caller.StartCoroutine(Animate(target, destination, onFinish));
    }

    private static IEnumerator Animate(GameObject target, Vector3 destination, Action onFinish = null, float speed = 5)
    {
        Vector3 startPos = target.transform.position;
        float startTime = Time.time;
        float interpolationValue = 0.0f;
        float timeNeeded = (startPos - destination).magnitude / speed;
        float timePassed = Time.time - startTime;
        while (timePassed < timeNeeded)
        {
            timePassed = (Time.time - startTime);
            interpolationValue = Mathf.Clamp01(timePassed / timeNeeded);
            interpolationValue = Mathf.Clamp01((Mathf.Sin((-Mathf.PI / 2) + (interpolationValue * Mathf.PI)) + 1) / 2);
            target.transform.position = Vector3.Lerp(startPos, destination, interpolationValue);
            yield return new WaitForEndOfFrame();
        }

        if(onFinish != null)
        {
            onFinish.Invoke();
        }
    }
}
