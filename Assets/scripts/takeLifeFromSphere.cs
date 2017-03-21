using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takeLifeFromSphere : MonoBehaviour
{
    public Transform playerTransform;
    public Transform sphereTransform;
    public float distanceFromPlayer;
    public bool yes;
    public bool locked;
    public int lockCounter;
    public float fixedDistance;

	void Start ()
    {
        yes = false;
        locked = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        distanceFromPlayer = Vector3.Distance(transform.position, playerTransform.position);
        if (distanceFromPlayer <= sphereTransform.localScale.x / 2 + fixedDistance) yes = true;
        else if (distanceFromPlayer >= sphereTransform.localScale.x / 2 + fixedDistance) yes = false;
        if (sphereTransform.localScale.x <= 4.5f) locked = true;
        if ((yes == true) && (locked == false))
        {
            if (Input.GetButton("E"))
            {
                sphereTransform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
                CharacterControlerBehaviourScript.life += 3;
            }
        }

        if(locked == true)
        {
            lockCounter += 1;
            if(lockCounter < 200)
            {
                if(sphereTransform.localScale.x >= 0.2) sphereTransform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
            }
            if(lockCounter > 5000000)
            {
                if(sphereTransform.localScale.x <= 17)sphereTransform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
                if(sphereTransform.localScale.x >= 17)
                {
                    lockCounter = 0;
                    locked = false;
                }
            }
        }
        if (sphereTransform.localScale.x <= 7.5) fixedDistance = 2.5f;
        if (sphereTransform.localScale.x >= 7.5) fixedDistance = 1.5f;
    }
}
