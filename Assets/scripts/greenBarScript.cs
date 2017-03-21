using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class greenBarScript : MonoBehaviour
{
	void Update ()
    {
        transform.localScale = new Vector3(CharacterControlerBehaviourScript.life/1000, transform.localScale.y, transform.localScale.z);
    }
}
