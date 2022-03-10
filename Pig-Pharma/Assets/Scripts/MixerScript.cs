using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MixerScript : MonoBehaviour
{

    bool IngredientWasA = false;

    public Texture renderTextureItemIngA;
    public Texture renderTextureItemIngB;
    public Texture renderTextureItemIngC;


    public RawImage ImageItem1;
    public RawImage ImageItem2;


    void OnMouseDown()
    {
        GameObject IngredientA = GameObject.Find("IngredientA");
        IngredientAScript speedController = IngredientA.GetComponent<IngredientAScript>();
        IngredientWasA = speedController.IngredientABool;

        if(IngredientWasA) {
            ImageItem1.texture = renderTextureItemIngA;

        }

    }
}
