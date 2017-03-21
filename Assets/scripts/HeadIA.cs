using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadIA : MonoBehaviour
{
    public bool stunned;
    public Transform target;
    public float distanceFromTarget;
    public float huntRange;

    // Use this for initialization
    void Start ( )
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update ( )
    {
        if (distanceFromTarget < huntRange) transform.LookAt(target);
    }
}