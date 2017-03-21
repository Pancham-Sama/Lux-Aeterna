using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSphere : MonoBehaviour
{
    public Transform Player;
    public float distanceFromPlayer;
    public Transform column;
    public bool getUp;
    public int framesCounter;
	
	// Update is called once per frame
    void Start ()
    {
        getUp = false;
        framesCounter = 0;
    }

	void Update ()
    {
        distanceFromPlayer = Vector3.Distance(transform.position, Player.position);
        if (distanceFromPlayer < 3) if (Input.GetButton("E") && framesCounter < 310) getUp = true;
        if (getUp == true)
        {
            framesCounter++;
            column.transform.position = new Vector3(column.transform.position.x, column.transform.position.y + 0.1f, column.transform.position.z);
        }
        if (framesCounter >= 310) getUp = false;
    }
}
