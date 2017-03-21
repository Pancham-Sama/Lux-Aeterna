using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class topologicsin : MonoBehaviour {

//	float initValue;
//	float finalValue;
//	float currentValue;
//
//	int framesDuration;
	int framesCounter;
//
//	bool startAnim;
//
//	Color initColor;

	// Use this for initialization
	void Start () {
//		initColor = GetComponent<Renderer> ().material.color;
//		initValue = 0.0f;
//		finalValue = 1.0f;
//		currentValue = initValue;

		framesCounter = 0;
//		framesDuration = 120;
//
//		startAnim = false;

		Application.targetFrameRate = 60;
	}
	
	// Update is called once per frame
	void Update () {
		framesCounter++;

		if (framesCounter > 120)
		{
			SceneManager.LoadScene (1);
		}

//		if (!startAnim) 
//		{
//			if (framesCounter > 60) 
//			{
//				framesCounter = 0;
//				startAnim = true;
//			}
//		} 
//		else 
//		{
//			if (framesCounter <= framesDuration) {
//				currentValue =  (framesCounter, initValue, finalValue - initValue, framesDuration);
//
//				GetComponent<Renderer> ().material.color = new Color (initColor.r, initColor.g, initColor.b, currentValue);
//			}
//		}
	}
}
