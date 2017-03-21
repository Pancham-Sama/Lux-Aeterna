using UnityEngine;
using System.Collections;

public class MouseBehaviourScript : MonoBehaviour
{
	// Update is called once per frame
	void Update ()
    {
	    if(Input.GetKeyUp(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else if(Input.GetMouseButtonUp(0))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
	}
}
