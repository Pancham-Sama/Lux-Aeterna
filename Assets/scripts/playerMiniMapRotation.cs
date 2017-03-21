using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMiniMapRotation : MonoBehaviour 
{
	public Transform playerTransform;
	void Update ()
	{
		transform.rotation = playerTransform.rotation;
	}
}
