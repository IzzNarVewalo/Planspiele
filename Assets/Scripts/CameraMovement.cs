using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CameraMovement : MonoBehaviour {
    [SerializeField]
    private GameObject _cameraPositions;
    private const float Speed = 10;
    private bool lockCameraMovement = false;
    private int positionCounter = 0;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.K))
            StartCoroutine(NextPosition());
    }

    public IEnumerator NextPosition() {
        if (lockCameraMovement)
            yield break;
        lockCameraMovement = true;
        if (positionCounter < 2)
            positionCounter++;
        Vector3 startPos = transform.position;
        float interpolationValue = 0.0f;

        while (interpolationValue < 1.0f) {
            interpolationValue += Speed * Time.deltaTime;
            transform.position = Vector3.Slerp(startPos, _cameraPositions.transform.GetChild(positionCounter).transform.position, interpolationValue);
            yield return new WaitForEndOfFrame();
        }
        lockCameraMovement = false;

    }

}
