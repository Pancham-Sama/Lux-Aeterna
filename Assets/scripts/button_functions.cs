using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class button_functions : MonoBehaviour
{
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit ();
#endif
    }
}
