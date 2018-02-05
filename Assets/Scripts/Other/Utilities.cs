using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utilities {

	public static bool GetBottomPosition(GameObject gameObject, out Vector3 bottomPosition)
    {
        MeshFilter meshFilter = gameObject.GetComponent<MeshFilter>();
        if(meshFilter != null)
        {
            bottomPosition = gameObject.transform.position;
            bottomPosition.y = gameObject.transform.position.y - meshFilter.mesh.bounds.extents.y * gameObject.transform.localScale.y;
            return true;
        }
        bottomPosition = Vector3.zero;
        return false;
    }

    public static Vector3 GetBottomOffset(GameObject gameObject)
    {
        Vector3 bottomPosition;
        if(GetBottomPosition(gameObject, out bottomPosition))
        {
            return gameObject.transform.position - bottomPosition;
        }
        return bottomPosition;
    }

}
