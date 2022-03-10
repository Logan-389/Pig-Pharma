using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PigController : MonoBehaviour
{

    string objectName = "";
    Ray ray;
    RaycastHit hit;

    public string heldIngredient = "none";

    /* Held Items */
    public Texture renderTextureBlank;
    public RawImage ImageItem;

    /* Icons of Ingredients */
    public Texture renderTextureItemIngA;
    public Texture renderTextureItemIngB;
    public Texture renderTextureItemIngC;
    public Texture renderTextureItemMixAB;
    public Texture renderTextureItemMixAC;
    public Texture renderTextureItemMixBC;
    public Texture renderTextureItemMixFail;

    /* Icons of Finished Drugs */
    public Texture renderTextureDrugAB;
    public Texture renderTextureDrugAC;
    public Texture renderTextureDrugBC;
    public Texture renderTextureDrugFail;

    /* Mixer UI*/
    int mixIndex = 0;
    public RawImage MixerImageItem1;
    public RawImage MixerImageItem2;
    string[] inMixer = new string[2];

    /* Cauldron UI */
    int cauldIndex = 0;
    public RawImage CauldronImageItem1;
    public RawImage CauldronImageItem2;
    string[] inCauldron = new string[2];

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
         GameObject IngredientA = GameObject.Find("IngredientA");
         IngredientAScript speedController = IngredientA.GetComponent<IngredientAScript>();
         objectName = speedController.ingredientName;

         GameObject IngredientB = GameObject.Find("IngredientB");
         IngredientAScript speedController2 = IngredientB.GetComponent<IngredientAScript>();
         objectName = speedController2.ingredientName;

         Debug.Log(objectName);*/

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit) && Input.GetMouseButtonDown(0))
        {
            objectName = hit.collider.name;
            //print(objectName);

            /* use the mixer */
            if ((heldIngredient == "IngredientA" || heldIngredient == "IngredientB" || heldIngredient == "IngredientC") && objectName == "Mixer" && mixIndex == 0)
            {
                inMixer[0] = heldIngredient;
                if (heldIngredient == "IngredientA")
                {
                    MixerImageItem1.texture = renderTextureItemIngA;
                }
                else if (heldIngredient == "IngredientB")
                {
                    MixerImageItem1.texture = renderTextureItemIngB;
                }
                else if (heldIngredient == "IngredientC")
                {
                    MixerImageItem1.texture = renderTextureItemIngC;
                }
                mixIndex++;
                heldIngredient = "none";
                objectName = "";
                ImageItem.texture = renderTextureBlank;
            }
            else if (heldIngredient != "none" && objectName == "Mixer" && mixIndex == 1)
            {
                inMixer[1] = heldIngredient;
                if (heldIngredient == "IngredientA")
                {
                    MixerImageItem2.texture = renderTextureItemIngA;
                }
                else if (heldIngredient == "IngredientB")
                {
                    MixerImageItem2.texture = renderTextureItemIngB;
                }
                else if (heldIngredient == "IngredientC")
                {
                    MixerImageItem2.texture = renderTextureItemIngC;
                }
                mixIndex++;
                heldIngredient = "none";
                objectName = "";
                ImageItem.texture = renderTextureBlank;
            }
            else if (objectName == "Mixer" && mixIndex == 2) // THE MIXER IS FULL!! TIME TO MIX!!
            {
                if ((inMixer[0] == "IngredientA" && inMixer[1] == "IngredientB") || (inMixer[0] == "IngredientB" && inMixer[1] == "IngredientA"))
                {
                    MixerImageItem1.texture = renderTextureItemMixAB;
                    MixerImageItem2.texture = renderTextureBlank;
                }
                else if ((inMixer[0] == "IngredientB" && inMixer[1] == "IngredientC") || (inMixer[0] == "IngredientC" && inMixer[1] == "IngredientB"))
                {
                    MixerImageItem1.texture = renderTextureItemMixBC;
                    MixerImageItem2.texture = renderTextureBlank;
                }
                else if ((inMixer[0] == "IngredientA" && inMixer[1] == "IngredientC") || (inMixer[0] == "IngredientC" && inMixer[1] == "IngredientA"))
                {
                    MixerImageItem1.texture = renderTextureItemMixAC;
                    MixerImageItem2.texture = renderTextureBlank;
                }
                else
                {
                    MixerImageItem1.texture = renderTextureItemMixFail;
                    MixerImageItem2.texture = renderTextureBlank;
                    print("FAILED MIX");
                }
                mixIndex = -1; // The mixer items need to be picked up
                objectName = "";
            }
            else if (objectName == "Mixer" && mixIndex == -1) // PICK UP THE MIX
            {
                if ((inMixer[0] == "IngredientA" && inMixer[1] == "IngredientB") || (inMixer[0] == "IngredientB" && inMixer[1] == "IngredientA"))
                {
                    ImageItem.texture = renderTextureItemMixAB;
                    MixerImageItem1.texture = renderTextureBlank;
                    heldIngredient = "IngredinetMixAB";
                }
                else if ((inMixer[0] == "IngredientB" && inMixer[1] == "IngredientC") || (inMixer[0] == "IngredientC" && inMixer[1] == "IngredientB"))
                {
                    ImageItem.texture = renderTextureItemMixBC;
                    MixerImageItem1.texture = renderTextureBlank;
                    heldIngredient = "IngredinetMixBC";
                }
                else if ((inMixer[0] == "IngredientA" && inMixer[1] == "IngredientC") || (inMixer[0] == "IngredientC" && inMixer[1] == "IngredientA"))
                {
                    ImageItem.texture = renderTextureItemMixAC;
                    MixerImageItem1.texture = renderTextureBlank;
                    heldIngredient = "IngredinetMixAC";
                }
                else
                {
                    ImageItem.texture = renderTextureItemMixFail;
                    MixerImageItem1.texture = renderTextureBlank;
                    heldIngredient = "IngredinetMixFail";
                    print("FAILED MIX");
                }
                inMixer[0] = "";
                inMixer[1] = "";
                mixIndex = 0; // The mixer items were picked up
                objectName = "";

            }

            /* Use the cauldron */

            if ((heldIngredient == "IngredinetMixAB" || heldIngredient == "IngredinetMixBC" || heldIngredient == "IngredinetMixAC") && objectName == "Cauldron" && cauldIndex == 0)
            {
                inCauldron[0] = heldIngredient;
                if (heldIngredient == "IngredinetMixAB")
                {
                    CauldronImageItem1.texture = renderTextureItemMixAB;
                } else if (heldIngredient == "IngredinetMixBC")
                {
                    CauldronImageItem1.texture = renderTextureItemMixBC;
                }
                else if (heldIngredient == "IngredinetMixAC")
                {
                    CauldronImageItem1.texture = renderTextureItemMixAC;
                }

                cauldIndex++;
                ImageItem.texture = renderTextureBlank;
                heldIngredient = "";
                objectName = "";
            } else if (objectName == "Cauldron" && cauldIndex == 1) //cook what is in the cauldron
            {
                if (inCauldron[0] == "IngredinetMixAB")
                {
                    CauldronImageItem1.texture = renderTextureDrugAB;
                }
                else if (inCauldron[0] == "IngredinetMixBC")
                {
                    CauldronImageItem1.texture = renderTextureDrugBC;
                }
                else if (inCauldron[0] == "IngredinetMixAC")
                {
                    CauldronImageItem1.texture = renderTextureDrugAC;
                }

                objectName = "";
                cauldIndex = -1; // PICK UP THE DRUG
            }
            else if (objectName == "Cauldron" && cauldIndex == -1) //pick up what is in the cauldron
            {
                if (inCauldron[0] == "IngredinetMixAB")
                {
                    CauldronImageItem1.texture = renderTextureBlank;
                    ImageItem.texture = renderTextureDrugAB;
                    heldIngredient = "DrugAB";
                }
                else if (inCauldron[0] == "IngredinetMixBC")
                {
                    CauldronImageItem1.texture = renderTextureBlank;
                    ImageItem.texture = renderTextureDrugBC;
                    heldIngredient = "DrugBC";
                }
                else if (inCauldron[0] == "IngredinetMixAC")
                {
                    CauldronImageItem1.texture = renderTextureBlank;
                    ImageItem.texture = renderTextureDrugAC;
                    heldIngredient = "DrugAC";
                }

                inCauldron[0] = "";
                objectName = "";
                cauldIndex = 0; // Cauldron Reset
            }
        

                /* the igredient that was just grabbed */
                if (objectName == "IngredientA" || objectName == "IngredientB" || objectName == "IngredientC")
            {
                heldIngredient = objectName;

                print(heldIngredient);
            }

            /* if the customer is clicked on */
            if (objectName == "CustomerA")
            {
                heldIngredient = "";
                objectName = "";
                ImageItem.texture = renderTextureBlank;
            }
        }

    }
}
