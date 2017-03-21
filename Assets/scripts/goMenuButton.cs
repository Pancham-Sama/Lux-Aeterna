using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goMenuButton : MonoBehaviour
{
    public void GoToMenu()
    {
        Application.LoadLevel("menu_scene");
    }
}

