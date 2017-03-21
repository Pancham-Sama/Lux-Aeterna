using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereLightMaterialOffset : MonoBehaviour
{
    public Vector2 mainTextureOffset;
    public float scrollSpeed;
    public float scrollSpeed2;
    public Renderer rend;

    void Start ( )
    {
        rend = GetComponent<Renderer>();
    }

    void Update ( )
    {
        float offset = Time.time * scrollSpeed;
        float offset2 = Time.time * scrollSpeed2;
        rend.material.SetTextureOffset("_MainTex", new Vector2(offset2, offset));
    }
}
