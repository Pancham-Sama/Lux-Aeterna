using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class linkIntensityToSpheres : MonoBehaviour
{
    public Light light;
    public Transform sphereTransform;
    void Start ()
    {
        light = GetComponent<Light>();
    }
    void Update ()
    {
        light.range = sphereTransform.transform.localScale.x/2 + 2;
    }
}
