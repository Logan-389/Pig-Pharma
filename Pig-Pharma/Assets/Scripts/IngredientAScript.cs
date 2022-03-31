using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngredientAScript : MonoBehaviour
{
    /* Update the score and cash */
    UpdateScoreScript scoreScript;

    public Texture renderTextureItem;
    public RawImage ImageItem;
    public string ingredientName = "";

    void OnMouseDown()
    {

            ImageItem.texture = renderTextureItem;
            ingredientName = gameObject.name;
            scoreScript = GameObject.FindGameObjectWithTag("Score").GetComponent<UpdateScoreScript>();
            scoreScript.loseCash(ingredientName);

    }

}
