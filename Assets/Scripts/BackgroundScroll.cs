using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    [SerializeField] private Renderer render;

    [SerializeField] private float scrollSpeed = 0.03f;
    void Update()
    {
        render.material.mainTextureOffset = render.material.mainTextureOffset + new Vector2(scrollSpeed * Time.deltaTime, 0);
    }
}
