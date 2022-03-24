using System.Collections;
using System.Collections.Generic;
using System;
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
    public Texture renderTextureItemIngD;
    public Texture renderTextureItemIngF;
    public Texture renderTextureItemMixAB;
    public Texture renderTextureItemMixAC;
    public Texture renderTextureItemMixBC;
    public Texture renderTextureItemStrainedD;
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

    /* Funnel UI */
    int funnelIndex = 0;
    public RawImage FunnelImageItem1;
    string[] inFunnel = new string[1];
    
    public float funnelTimer = 0;
    private string displayFunnelString;
    public Text displayFunnelTimer;
    float fSeconds;
    float fMinutes;

    /* Lamp UI */
    int lampIndex = 0;
    public RawImage LampImageItem1;
    string[] inLamp = new string[1];

    /* Pig Display */
    public Texture PigNormImg;
    public Texture PigFarmImg;
    public GameObject Pig;
    Renderer pigRenderer;
    public bool actingLikeAPig = false; /* if you are acting like a pig, the farmer will leave you alone */

    // Start is called before the first frame update
    void Start()
    {
        pigRenderer = Pig.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit) && Input.GetMouseButtonDown(0))
        {
            objectName = hit.collider.name;
            //print(objectName);

            if(objectName == "Pig" && !actingLikeAPig)
            {
                pigRenderer.material.SetTexture("_MainTex", PigFarmImg);
                actingLikeAPig = true;
            } else if(objectName == "Pig" && actingLikeAPig)
            {
                pigRenderer.material.SetTexture("_MainTex", PigNormImg);
                actingLikeAPig = false;
            }


            /* use the mixer */
            //(heldIngredient == "IngredientA" || heldIngredient == "IngredientB" || heldIngredient == "IngredientC" || heldIngredient == "IngredientD" || heldIngredient == "IngredientF")
            if (heldIngredient != "none" && objectName == "Mixer" && mixIndex == 0)
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
                else if (heldIngredient == "IngredientD")
                {
                    MixerImageItem1.texture = renderTextureItemIngD;
                } 
                else if (heldIngredient == "IngredientF")
                {
                    MixerImageItem1.texture = renderTextureItemIngF;
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
                else if (heldIngredient == "IngredientD")
                {
                    MixerImageItem2.texture = renderTextureItemIngD;
                }
                else if (heldIngredient == "IngredientF")
                {
                    MixerImageItem2.texture = renderTextureItemIngF;
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
                }
                else if (heldIngredient == "IngredinetMixBC")
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
            }
            else if (objectName == "Cauldron" && cauldIndex == 1) //cook what is in the cauldron
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

            /* use the funnel */
            if (heldIngredient == "IngredientD" && objectName == "Funnel" && funnelIndex == 0)
            {
                inFunnel[0] = heldIngredient;
                if (heldIngredient == "IngredientD")
                {
                    FunnelImageItem1.texture = renderTextureItemIngD;
                }
                funnelIndex++;
                ImageItem.texture = renderTextureBlank;
                heldIngredient = "";
                objectName = "";
            } else if (objectName == "Funnel" && funnelIndex == 1)
            {
                if(inFunnel[0] == "IngredientD")
                {
                    funnelTimer = 15;
                    funnelIndex = 2;
                }
            } else if(objectName == "Funnel" & funnelIndex == -1)
            {
                if(inFunnel[0] == "IngredientD")
                {
                    FunnelImageItem1.texture = renderTextureBlank;
                    ImageItem.texture = renderTextureItemStrainedD;
                    heldIngredient = "Strained Mash D";
                }
                objectName = "";
                inFunnel[0] = "";
                funnelIndex = 0;
            }

            /* use the light */
            /*
            if (heldIngredient == "IngredientF" && objectName == "Lamp" && lampIndex == 0)
            {
                inLamp[0] = heldIngredient;
                if (heldIngredient == "IngredientF")
                {
                    LampImageItem1.texture = renderTextureItemIngF;
                }
                lampIndex++;
                ImageItem.texture = renderTextureBlank;
                heldIngredient = "";
                objectName = "";
             } else if (objectName == "Lamp" && lampIndex == 1)
             {
           
             }
            */

        /* the igredient that was just grabbed */
        if (objectName == "IngredientA" || objectName == "IngredientB" || objectName == "IngredientC" || objectName == "IngredientD" || objectName == "IngredientF")
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

        /* Decriment Timers */
        //Funnel Timer
        if (funnelTimer > 0)
        {
            funnelTimer -= Time.deltaTime;
            fSeconds = Mathf.FloorToInt(funnelTimer % 60);
            fMinutes = 0;
            displayFunnelTimer.text = string.Format("{0:00}:{1:00}", fMinutes, fSeconds);
            funnelIndex = 2;
        } else if (funnelTimer <= 0 && funnelIndex == 2)
        {
            funnelTimer = 0;
            fSeconds = 0;
            fMinutes = 0;
            displayFunnelTimer.text = string.Format("{0:00}:{1:00}", fMinutes, fSeconds);
            Debug.Log("Done cooking");
            funnelIndex = -1; // Get ready to pick items up!
        }

    }
}
