using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class HighlightOnMouseOver : MonoBehaviour
{

    public Texture renderTextureItem;
    private Color startcolor;
    Renderer thisRend;
    Color highColor = new Color(0.5f, 0.5f, 0.5f, 1.0f);


    void Start()
    {
        thisRend = this.gameObject.GetComponent<Renderer>();
    }

        void OnMouseEnter()
    {
        thisRend.material.SetColor("_Color", highColor);
    }
    void OnMouseExit()
    {
        thisRend.material.SetColor("_Color", Color.white);
    }
}
