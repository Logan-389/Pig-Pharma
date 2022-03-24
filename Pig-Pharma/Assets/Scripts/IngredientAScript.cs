using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngredientAScript : MonoBehaviour
{

    public Texture renderTextureItem;
    public RawImage ImageItem;
    public string ingredientName = "";

    void OnMouseDown()
    {

            ImageItem.texture = renderTextureItem;
            ingredientName = gameObject.name;
    
       
    }

}
