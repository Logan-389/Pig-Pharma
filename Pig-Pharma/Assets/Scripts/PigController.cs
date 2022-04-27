using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PigController : MonoBehaviour
{

    string objectName = "";
    Ray ray;
    RaycastHit hit;

    public string heldIngredient = "none";

    /* Held Items */
    public Texture renderTextureBlank;
    public RawImage ImageItem;

    /* Icons of Raw Ingredients */
    public Texture renderTextureItemIngA;
    public Texture renderTextureItemIngB;
    public Texture renderTextureItemIngC;
    public Texture renderTextureItemIngD;
    public Texture renderTextureItemIngF;
    public Texture renderTextureItemMixFail;

    /* Mixed Intredients */
    public Texture renderTextureItemMixAB;
    public Texture renderTextureItemMixAC;
    public Texture renderTextureItemMixBC;
    public Texture renderTextureItemMixDF;
    public Texture renderTextureItemMixAA;

    /* Funnel Intredients */
    public Texture renderTextureItemStrainedD;
    public Texture renderTextureSyrupF;
    public Texture renderTextureWormyConcoction;
    public Texture renderTextureBlazingBrew;

    /* Icons of Finished Drugs */
    public Texture renderTextureDrugAB;
    public Texture renderTextureDrugAC;
    public Texture renderTextureDrugBC;
    public Texture renderTextureDrugFail;

    /* Mixer UI*/
    public GameObject Mixer;
    int mixIndex = 0;
    public RawImage MixerImageItem1;
    public RawImage MixerImageItem2;
    string[] inMixer = new string[2];
    public Texture emptyMixer;
    public Texture fullMixerA;
    public Texture fullMixerB;
    public Texture fullMixerC;
    public Texture fullMixerD;
    public Texture fullMixerF;
    public Texture fullMixerAB;
    public Texture fullMixerAC;
    public Texture fullMixerBC;
    public Texture fullMixerDF;
    Renderer mixerRenderer;
    public AudioSource mixerNoise;

    /* Cauldron UI */
    public GameObject Cauldron;
    int cauldIndex = 0;
    public RawImage CauldronImageItem1;
    public RawImage CauldronImageItem2;
    string[] inCauldron = new string[2];
    public Texture emptyCauldron;
    public Texture fullCauldronAA;
    public Texture fullCauldronAB;
    public Texture fullCauldronAC;
    public Texture fullCauldronBC;
    public Texture fullCauldronDF;
    Renderer cauldronRenderer;
    public AudioSource cauldronNoise;

    /* Funnel UI */
    public GameObject Funnel;
    int funnelIndex = 0;
    public RawImage FunnelImageItem1;
    string[] inFunnel = new string[1];
    public Texture emptyFunnel;
    public Texture fullFunnelD;
    public Texture fullFunnelF;
    public Texture fullFunnelDF;
    public Texture fullFunnelAA;
    Renderer funnelRenderer;

    public float funnelTimer = 0;
    private string displayFunnelString;
    public Text displayFunnelTimer;
    float fSeconds;
    float fMinutes;

    public AudioSource funnelTimerSound;
    public AudioSource trashSound;
    public AudioSource funnelNoise;

    /* Explosion Stuff */
    public GameObject Explosion;
    public GameObject GameBGM;
    public GameObject InventoryCanvas;
    public AudioSource ExplosionNoise;
    float timeTilDeath = 0f;

    /* Pig Display */
    public Texture PigNormImg;
    public Texture PigFarmImg;
    public GameObject Pig;
    Renderer pigRenderer;
    bool actingLikeAPig = false; /* if you are acting like a pig, the farmer will leave you alone */

    // Start is called before the first frame update
    void Start()
    {
        pigRenderer = Pig.GetComponent<Renderer>();
        mixerRenderer = Mixer.GetComponent<Renderer>();
        cauldronRenderer = Cauldron.GetComponent<Renderer>();
        funnelRenderer = Funnel.GetComponent<Renderer>();

        mixerRenderer.material.SetTexture("_MainTex", emptyMixer);
        cauldronRenderer.material.SetTexture("_MainTex", emptyCauldron);
        funnelRenderer.material.SetTexture("_MainTex", emptyFunnel);
    }

    // Update is called once per frame
    void Update()
    {

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit) && Input.GetMouseButtonDown(0))
        {
            objectName = hit.collider.name;

            if(objectName == "Pig" && !actingLikeAPig)
            {
                pigRenderer.material.SetTexture("_MainTex", PigFarmImg);
                actingLikeAPig = true;
            } else if(actingLikeAPig)
            {
                pigRenderer.material.SetTexture("_MainTex", PigNormImg);
                actingLikeAPig = false;
            }


            /* use the mixer */
            //heldIngredient  == "IngredientA" || heldIngredient  == "IngredientB" || heldIngredient  == "IngredientC" || heldIngredient  == "IngredientD" || heldIngredient  == "IngredientF"
            if ((heldIngredient == "IngredientA" || heldIngredient == "IngredientB" || heldIngredient == "IngredientC" || heldIngredient == "IngredientD" || heldIngredient == "IngredientF") && objectName == "Mixer" && mixIndex == 0)
            {
                inMixer[0] = heldIngredient;
                if (heldIngredient == "IngredientA")
                {
                    MixerImageItem1.texture = renderTextureItemIngA;
                    mixerRenderer.material.SetTexture("_MainTex", fullMixerA);
                }
                else if (heldIngredient == "IngredientB")
                {
                    MixerImageItem1.texture = renderTextureItemIngB;
                    mixerRenderer.material.SetTexture("_MainTex", fullMixerB);
                }
                else if (heldIngredient == "IngredientC")
                {
                    MixerImageItem1.texture = renderTextureItemIngC;
                    mixerRenderer.material.SetTexture("_MainTex", fullMixerC);
                } 
                else if (heldIngredient == "IngredientD")
                {
                    MixerImageItem1.texture = renderTextureItemIngD;
                    mixerRenderer.material.SetTexture("_MainTex", fullMixerD);
                } 
                else if (heldIngredient == "IngredientF")
                {
                    MixerImageItem1.texture = renderTextureItemIngF;
                    mixerRenderer.material.SetTexture("_MainTex", fullMixerF);
                }
                //mixerRenderer.material.SetTexture("_MainTex", fullMixer);
                mixIndex++;
                heldIngredient = "none";
                objectName = "";
                ImageItem.texture = renderTextureBlank;
            }
            else if ((heldIngredient == "IngredientA" || heldIngredient == "IngredientB" || heldIngredient == "IngredientC" || heldIngredient == "IngredientD" || heldIngredient == "IngredientF") && objectName == "Mixer" && mixIndex == 1)
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
                mixerNoise.Play();
                if ((inMixer[0] == "IngredientA" && inMixer[1] == "IngredientB") || (inMixer[0] == "IngredientB" && inMixer[1] == "IngredientA"))
                {
                    MixerImageItem1.texture = renderTextureItemMixAB;
                    MixerImageItem2.texture = renderTextureBlank;
                    mixerRenderer.material.SetTexture("_MainTex", fullMixerAB);
                }
                else if ((inMixer[0] == "IngredientB" && inMixer[1] == "IngredientC") || (inMixer[0] == "IngredientC" && inMixer[1] == "IngredientB"))
                {
                    MixerImageItem1.texture = renderTextureItemMixBC;
                    MixerImageItem2.texture = renderTextureBlank;
                    mixerRenderer.material.SetTexture("_MainTex", fullMixerBC);
                }
                else if ((inMixer[0] == "IngredientA" && inMixer[1] == "IngredientC") || (inMixer[0] == "IngredientC" && inMixer[1] == "IngredientA"))
                {
                    MixerImageItem1.texture = renderTextureItemMixAC;
                    MixerImageItem2.texture = renderTextureBlank;
                    mixerRenderer.material.SetTexture("_MainTex", fullMixerAC);
                }
                else if ((inMixer[0] == "IngredientD" && inMixer[1] == "IngredientF") || (inMixer[0] == "IngredientF" && inMixer[1] == "IngredientD"))
                {
                    MixerImageItem1.texture = renderTextureItemMixDF;
                    MixerImageItem2.texture = renderTextureBlank;
                    mixerRenderer.material.SetTexture("_MainTex", fullMixerDF);
                }
                else if ((inMixer[0] == "IngredientA" && inMixer[1] == "IngredientA") || (inMixer[0] == "IngredientA" && inMixer[1] == "IngredientA"))
                {
                    MixerImageItem1.texture = renderTextureItemMixAA;
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
                    heldIngredient = "IngredientMixAB";
                }
                else if ((inMixer[0] == "IngredientB" && inMixer[1] == "IngredientC") || (inMixer[0] == "IngredientC" && inMixer[1] == "IngredientB"))
                {
                    ImageItem.texture = renderTextureItemMixBC;
                    MixerImageItem1.texture = renderTextureBlank;
                    heldIngredient = "IngredientMixBC";
                }
                else if ((inMixer[0] == "IngredientA" && inMixer[1] == "IngredientC") || (inMixer[0] == "IngredientC" && inMixer[1] == "IngredientA"))
                {
                    ImageItem.texture = renderTextureItemMixAC;
                    MixerImageItem1.texture = renderTextureBlank;
                    heldIngredient = "IngredientMixAC";
                }
                else if((inMixer[0] == "IngredientD" && inMixer[1] == "IngredientF") || (inMixer[0] == "IngredientF" && inMixer[1] == "IngredientD"))
                {
                    ImageItem.texture = renderTextureItemMixDF;
                    MixerImageItem1.texture = renderTextureBlank;
                    heldIngredient = "IngredientMixDF";
                }
                else if ((inMixer[0] == "IngredientA" && inMixer[1] == "IngredientA") || (inMixer[0] == "IngredientA" && inMixer[1] == "IngredientA"))
                {
                    ImageItem.texture = renderTextureItemMixAA;
                    MixerImageItem1.texture = renderTextureBlank;
                    heldIngredient = "IngredientMixAA";
                }
                else
                {
                    ImageItem.texture = renderTextureItemMixFail;
                    MixerImageItem1.texture = renderTextureBlank;
                    heldIngredient = "IngredientMixFail";
                    print("FAILED MIX");
                }

                mixerRenderer.material.SetTexture("_MainTex", emptyMixer);
                inMixer[0] = "";
                inMixer[1] = "";
                mixIndex = 0; // The mixer items were picked up
                objectName = "";

            }

            /* Clear Mixer Buton Pressed */
            if(objectName == "Mixer_Clear")
            {
                Debug.Log("So, you want to clear the mixer!?");
                trashSound.Play();
                MixerImageItem1.texture = renderTextureBlank;
                MixerImageItem2.texture = renderTextureBlank;
                mixerRenderer.material.SetTexture("_MainTex", emptyMixer);
                inMixer[0] = "";
                inMixer[1] = "";
                mixIndex = 0;
                objectName = "";
            }


            /* Use the cauldron */
            if ((heldIngredient == "IngredientMixAB" || heldIngredient == "IngredientMixBC" || heldIngredient == "IngredientMixAC" || heldIngredient == "IngredientMixAA") && objectName == "Cauldron" && cauldIndex == 0)
            {
                inCauldron[0] = heldIngredient;
                if (heldIngredient == "IngredientMixAB")
                {
                    CauldronImageItem1.texture = renderTextureItemMixAB;
                    cauldronRenderer.material.SetTexture("_MainTex", fullCauldronAB);
                }
                else if (heldIngredient == "IngredientMixBC")
                {
                    CauldronImageItem1.texture = renderTextureItemMixBC;
                    cauldronRenderer.material.SetTexture("_MainTex", fullCauldronBC);
                }
                else if (heldIngredient == "IngredientMixAC")
                {
                    CauldronImageItem1.texture = renderTextureItemMixAC;
                    cauldronRenderer.material.SetTexture("_MainTex", fullCauldronAC);
                }
                else if (heldIngredient == "IngredientMixAA")
                {
                    CauldronImageItem1.texture = renderTextureItemMixAA;
                    cauldronRenderer.material.SetTexture("_MainTex", fullCauldronAA);
                }

                //cauldronRenderer.material.SetTexture("_MainTex", fullCauldron);
                cauldIndex++;
                ImageItem.texture = renderTextureBlank;
                heldIngredient = "";
                objectName = "";
            }
            else if (objectName == "Cauldron" && cauldIndex == 1) //cook what is in the cauldron
            {
                cauldronNoise.Play();
                if (inCauldron[0] == "IngredientMixAB")
                {
                    CauldronImageItem1.texture = renderTextureDrugAB;
                }
                else if (inCauldron[0] == "IngredientMixBC")
                {
                    CauldronImageItem1.texture = renderTextureDrugBC;
                }
                else if (inCauldron[0] == "IngredientMixAC")
                {
                    CauldronImageItem1.texture = renderTextureDrugAC;
                }
                else if (inCauldron[0] == "IngredientMixAA")
                {
                    GameBGM.SetActive(false);
                    InventoryCanvas.SetActive(false);
                    Explosion.SetActive(true);
                    ExplosionNoise.Play();
                    timeTilDeath = 4;
                }

                objectName = "";
                cauldIndex = -1; // PICK UP THE DRUG
            }
            else if (objectName == "Cauldron" && cauldIndex == -1) //pick up what is in the cauldron
            {
                if (inCauldron[0] == "IngredientMixAB")
                {
                    CauldronImageItem1.texture = renderTextureBlank;
                    ImageItem.texture = renderTextureDrugAB;
                    heldIngredient = "DrugAB";
                }
                else if (inCauldron[0] == "IngredientMixBC")
                {
                    CauldronImageItem1.texture = renderTextureBlank;
                    ImageItem.texture = renderTextureDrugBC;
                    heldIngredient = "DrugBC";
                }
                else if (inCauldron[0] == "IngredientMixAC")
                {
                    CauldronImageItem1.texture = renderTextureBlank;
                    ImageItem.texture = renderTextureDrugAC;
                    heldIngredient = "DrugAC";
                }

                cauldronRenderer.material.SetTexture("_MainTex", emptyCauldron);
                inCauldron[0] = "";
                objectName = "";
                cauldIndex = 0; // Cauldron Reset
            }

            /* Clear Cauldron Buton Pressed */
            if (objectName == "Cauldron_Clear")
            {
                Debug.Log("So, you want to clear the cauldron!?");
                trashSound.Play();
                CauldronImageItem1.texture = renderTextureBlank;
                CauldronImageItem2.texture = renderTextureBlank;
                cauldronRenderer.material.SetTexture("_MainTex", emptyCauldron);
                inCauldron[0] = "";
                inCauldron[1] = "";
                cauldIndex = 0;
                objectName = "";
            }

            /* use the funnel */
            if ((heldIngredient == "IngredientD" || heldIngredient == "IngredientF" || heldIngredient == "IngredientMixDF" || heldIngredient == "IngredientMixAA") && objectName == "Funnel" && funnelIndex == 0)
            {
                inFunnel[0] = heldIngredient;
                if (heldIngredient == "IngredientD")
                {
                    FunnelImageItem1.texture = renderTextureItemIngD;
                    funnelRenderer.material.SetTexture("_MainTex", fullFunnelD);
                } 
                else if (heldIngredient == "IngredientF")
                {
                    FunnelImageItem1.texture = renderTextureItemIngF;
                    funnelRenderer.material.SetTexture("_MainTex", fullFunnelF);
                } 
                else if (heldIngredient == "IngredientMixDF")
                {
                    FunnelImageItem1.texture = renderTextureItemMixDF;
                    funnelRenderer.material.SetTexture("_MainTex", fullFunnelDF);
                }
                else if (heldIngredient == "IngredientMixAA")
                {
                    FunnelImageItem1.texture = renderTextureItemMixAA;
                    funnelRenderer.material.SetTexture("_MainTex", fullFunnelAA);
                }
                funnelIndex++;
                ImageItem.texture = renderTextureBlank;
                //funnelRenderer.material.SetTexture("_MainTex", fullFunnel);
                heldIngredient = "";
                objectName = "";
            } else if (objectName == "Funnel" && funnelIndex == 1)
            {
                funnelNoise.Play();
                if(inFunnel[0] == "IngredientD")
                {
                    funnelTimer = 15;
                    funnelIndex = 2;
                } else if(inFunnel[0] == "IngredientF")
                {
                    funnelTimer = 16;
                    funnelIndex = 2;
                } else if(inFunnel[0] == "IngredientMixDF")
                {
                    funnelTimer = 20;
                    funnelIndex = 2;
                }
                else if (inFunnel[0] == "IngredientMixAA")
                {
                    funnelTimer = 20;
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
                else if(inFunnel[0] == "IngredientF")
                {
                    FunnelImageItem1.texture = renderTextureBlank;
                    ImageItem.texture = renderTextureSyrupF;
                    heldIngredient = "Pink Syrup F";
                }
                else if(inFunnel[0] == "IngredientMixDF")
                {
                    FunnelImageItem1.texture = renderTextureBlank;
                    ImageItem.texture = renderTextureWormyConcoction;
                    heldIngredient = "Wormy Concotion";
                }
                else if (inFunnel[0] == "IngredientMixAA")
                {
                    FunnelImageItem1.texture = renderTextureBlank;
                    ImageItem.texture = renderTextureBlazingBrew;
                    heldIngredient = "Blazing Brew";
                }
                objectName = "";
                inFunnel[0] = "";
                funnelRenderer.material.SetTexture("_MainTex", emptyFunnel);
                funnelIndex = 0;
            }

            /* Clear Funnel Buton Pressed */
            if (objectName == "Funnel_Clear")
            {
                Debug.Log("So, you want to clear the funnel!?");
                funnelNoise.Stop();
                trashSound.Play();
                FunnelImageItem1.texture = renderTextureBlank;
                funnelRenderer.material.SetTexture("_MainTex", emptyFunnel);
                inFunnel[0] = "";
                funnelIndex = 0;
                objectName = "";
                /* Rest the timer */
                funnelTimer = 0;
                fSeconds = Mathf.FloorToInt(funnelTimer % 60);
                fMinutes = 0;
                displayFunnelTimer.text = string.Format("{0:00}:{1:00}", fMinutes, fSeconds);
            }


            /* the igredient that was just grabbed */
                if (objectName == "IngredientA" || objectName == "IngredientB" || objectName == "IngredientC" || objectName == "IngredientD" || objectName == "IngredientF")
            {
                heldIngredient = objectName;
            }

            /* if the customer is clicked on */
            if (objectName == "CustomerA" || objectName == "CustomerB" || objectName == "CustomerC" || objectName == "CustomerD")
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
            funnelTimerSound.Play();
            Debug.Log("Done cooking");
            funnelIndex = -1; // Get ready to pick items up!
        }

        if(timeTilDeath > 0)
        {
            timeTilDeath -= Time.deltaTime;
        } else if (timeTilDeath < 0) /* RIP */
        {
            SceneManager.LoadScene("BusinessExplosion");
        }
    }
}
