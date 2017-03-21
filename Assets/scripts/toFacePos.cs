using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toFacePos : MonoBehaviour
{
    public Transform playerTransform;
    public Transform toFace;
    // Update is called once per frame
    void Update ()
    {
        toFace.transform.position = new Vector3(toFace.transform.position.x, playerTransform.position.y, toFace.transform.position.z);
	}
}
