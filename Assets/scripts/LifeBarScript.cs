using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBarScript : MonoBehaviour
{
    public Transform target;
    public Vector3 direction;
	
	// Update is called once per frame
	void Update ()
    {
        CalculateDirection();
        Vector3 targetPostition = new Vector3(target.position.x, this.transform.position.y, target.position.z);
        this.transform.LookAt(targetPostition);
    }

    void CalculateDirection ( )
    {
        direction = target.position - transform.position;
        direction = direction.normalized;
    }
}
