using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class luxaeternapass : MonoBehaviour {
	int framesCounter;
	// Use this for initialization
	void Start () {
		framesCounter = 0;
		Application.targetFrameRate = 60;
	}
	
	// Update is called once per frame
	void Update () {
		framesCounter++;

		if (framesCounter > 120)
		{
			SceneManager.LoadScene (2);
		}
	}
}
