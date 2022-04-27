using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CustomerScript : MonoBehaviour
{
    public TextMeshPro requestA;
    int rand;
    bool orderTaken = false;
    string requestedDrug;
    string drugGiven;

    /* Enter pharma... */
    bool atPharma = false;
    float timeTilAtPharma = 10;

    /* Update the score and cash */
    UpdateScoreScript scoreScript;

    /* Customer Display */
    public Texture CustomerHappyImg;
    public Texture CustomerNeutralImg;
    public Texture CustomerMadImg;
    public GameObject Customer;
    Renderer customerRenderer;
    float customerSatisfaction = 20;
    int customerSatIndex = 0;
    bool timeOut = false;

    /* Customer Textures */
    int indexOfAnimalType;          // 0 = horse, 1 = cow,
    public Texture horseText1;
    public Texture horseText2;
    public Texture horseText3;
    public Texture cowText1;
    public Texture cowText2;
    public Texture cowText3;
    public Texture catText1;
    public Texture catText2;
    public Texture catText3;
    public Texture chickenText1;
    public Texture chickenText2;
    public Texture chickenText3;
    public Texture dogText1;
    public Texture dogText2;
    public Texture dogText3;
    public Texture duckText1;
    public Texture duckText2;
    public Texture duckText3;
    public Texture goatText1;
    public Texture goatText2;
    public Texture goatText3;
    public Texture sheepText1;
    public Texture sheepText2;
    public Texture sheepText3;

    /* Audio */
    public AudioSource enterSound;
    public AudioSource bellSound;
    public AudioSource AngrySighA;
    public AudioSource AngrySighB;
    public AudioSource AngrySighC;
    public AudioSource AngryGruntA;
    public AudioSource AngryGruntB;
    public AudioSource AngryGruntC;

    /* Customer Wandering */
    float timeUntilWandering = 10;
    float xPos;
    float zPos;
    float newXPos;
    float newZPos;

    void OnMouseDown()
    {
        if(!orderTaken)
        {
            rand = Random.Range(0, 10);
            if (rand == 0 || rand == 7)
            {
                requestA.SetText("I want a... \ngreen pill");
                requestedDrug = "DrugBC";
            }
            else if (rand == 1 || rand == 8)
            {
                requestA.SetText("I want a... \npurple pill");
                requestedDrug = "DrugAB";
            }
            else if (rand == 2 || rand == 9)
            {
                requestA.SetText("I want a... \norange pill");
                requestedDrug = "DrugAC";
            }
            else if (rand == 3)
            {
                requestA.SetText("I want a...\ngreen strained \nmash");
                requestedDrug = "Strained Mash D";
            }
            else if (rand == 4)
            {
                requestA.SetText("I want a...\nPink Syrup F");
                requestedDrug = "Pink Syrup F";
            }
            else if (rand == 5)
            {
                requestA.SetText("I want a...\nWormy Concotion");
                requestedDrug = "Wormy Concotion";
            }
            else if (rand == 6)
            {
                requestA.SetText("I want a...\nBlazing Brew");
                requestedDrug = "Blazing Brew";
            }
            else
            {
                requestA.SetText("RAND FAILED");
            }
            orderTaken = true;
        } else if(orderTaken)
        {
            GameObject Pig = GameObject.Find("Pig");
            PigController controller1 = Pig.GetComponent<PigController>();
            drugGiven = controller1.heldIngredient;
            print("You gave me the drug: " + drugGiven);

            if(drugGiven == requestedDrug)
            {
                bellSound.Play();
                scoreScript = GameObject.FindGameObjectWithTag("Score").GetComponent<UpdateScoreScript>();
                scoreScript.updateScore(drugGiven);
                startOver();
            } 
            else if(drugGiven.Length <= 0)
            {
                print("Woops");
            }
            else
            {
                scoreScript = GameObject.FindGameObjectWithTag("Score").GetComponent<UpdateScoreScript>();
                scoreScript.updateLives();
                startOver();
            }
        }

    }

        public void startOver()
          {

            transform.position = new Vector3(8.8f, 1f, -72f);    //LEAVE THE PHARMA
            atPharma = false;
            timeTilAtPharma = Random.Range(3, 25);          //Wait to enter the pharma
            orderTaken = false;
            customerSatIndex = 0;
            customerSatisfaction = 20;
            getOurAnimalType1();
            requestA.SetText("I want a...");
            }

          //Fail if you time out
        public void timeOutMethod(bool timeOut)
         {
            if(timeOut)
            {
            Debug.Log("Time out!!!!");
            timeOut = false;
            scoreScript = GameObject.FindGameObjectWithTag("Score").GetComponent<UpdateScoreScript>();  /* you lost so you lose (stuff) */
            scoreScript.updateLives();

            startOver();
             }
        }
       
        private void getOurAnimalType1()
          {
             indexOfAnimalType = Random.Range(0, 8);             /*what kind of animal are we?*/
            if (indexOfAnimalType == 0)
            {
                customerRenderer.material.SetTexture("_MainTex", horseText1);
            }
            else if (indexOfAnimalType == 1)
            {
                customerRenderer.material.SetTexture("_MainTex", cowText1);   
            }
            else if (indexOfAnimalType == 2)
            {
                customerRenderer.material.SetTexture("_MainTex", catText1);
            }
            else if (indexOfAnimalType == 3)
            {
                customerRenderer.material.SetTexture("_MainTex", chickenText1);
            }
            else if (indexOfAnimalType == 4)
            {
                customerRenderer.material.SetTexture("_MainTex", dogText1);
            }
            else if (indexOfAnimalType == 5)
            {
                customerRenderer.material.SetTexture("_MainTex", duckText1);
            }
            else if (indexOfAnimalType == 6)
            {
                customerRenderer.material.SetTexture("_MainTex", goatText1);
            }
            else if (indexOfAnimalType == 7)
            {
                customerRenderer.material.SetTexture("_MainTex", sheepText1);
            }
            else
            {
                customerRenderer.material.SetTexture("_MainTex", cowText1);
            }
           }
        
        private void sighAngrily()
        {
            int randAudio = Random.Range(0, 3);
            if(randAudio == 0)
            {
                AngrySighA.Play();
            } else if(randAudio == 1)
            {
                AngrySighB.Play();
            } else
            {
                AngrySighC.Play();
            }  
        }

        private void gruntAngrily()
        {
            int randAudio = Random.Range(0, 3);
            if (randAudio == 0)
            {
                AngryGruntA.Play();
            }
            else if (randAudio == 1)
            {
                AngryGruntB.Play();
            }
            else
            {
                AngryGruntC.Play();
            }
        }

    private void getOurAnimalType2()
        {
            if (indexOfAnimalType == 0)
            {
                customerRenderer.material.SetTexture("_MainTex", horseText2);
            }
            else if (indexOfAnimalType == 1)
            {
                customerRenderer.material.SetTexture("_MainTex", cowText2);
            }
            else if (indexOfAnimalType == 2)
            {
                customerRenderer.material.SetTexture("_MainTex", catText2);
            }
            else if (indexOfAnimalType == 3)
            {
                customerRenderer.material.SetTexture("_MainTex", chickenText2);
            }
            else if (indexOfAnimalType == 4)
            {
                customerRenderer.material.SetTexture("_MainTex", dogText2);
            }
            else if (indexOfAnimalType == 5)
            {
                customerRenderer.material.SetTexture("_MainTex", duckText2);
            }
            else if (indexOfAnimalType == 6)
            {
                customerRenderer.material.SetTexture("_MainTex", goatText2);
            }
            else if (indexOfAnimalType == 7)
            {
                customerRenderer.material.SetTexture("_MainTex", sheepText2);
            }
             else
            {
                customerRenderer.material.SetTexture("_MainTex", cowText2);
            }
        }

        private void getOurAnimalType3()
        {
            if (indexOfAnimalType == 0)
            {
                customerRenderer.material.SetTexture("_MainTex", horseText3);
            }
            else if (indexOfAnimalType == 1)
            {
                customerRenderer.material.SetTexture("_MainTex", cowText3);
            }
            else if (indexOfAnimalType == 2)
            {
                customerRenderer.material.SetTexture("_MainTex", catText3);
            }
            else if (indexOfAnimalType == 3)
            {
                customerRenderer.material.SetTexture("_MainTex", chickenText3);
            }
            else if (indexOfAnimalType == 4)
            {
                customerRenderer.material.SetTexture("_MainTex", dogText3);
            }
            else if (indexOfAnimalType == 5)
            {
                customerRenderer.material.SetTexture("_MainTex", duckText3);
            }
            else if (indexOfAnimalType == 6)
            {
                customerRenderer.material.SetTexture("_MainTex", goatText3);
            }
            else if (indexOfAnimalType == 7)
            {
                customerRenderer.material.SetTexture("_MainTex", sheepText3);
            }
            else
            {
                customerRenderer.material.SetTexture("_MainTex", cowText3);
            }
        }

    // Start is called before the first frame update
    void Start()
    {
        customerRenderer = Customer.GetComponent<Renderer>();
        transform.position = new Vector3(8.8f, 1f, -72f);
        timeTilAtPharma = Random.Range(3, 25);
        getOurAnimalType1();

    }

    // Update is called once per frame
    void Update()
    {
        if(!atPharma)
        {
            //get ready to GO to pharma
            if (timeTilAtPharma > 0)
            {
                timeTilAtPharma -= Time.deltaTime; 
            } else                                                  // NOW GO TO THE PHARMA!
            {
                xPos = Random.Range(-13, 16);
                zPos = Random.Range(-43, -35);
                transform.position = new Vector3(xPos, 1f, zPos);
                atPharma = true;
                enterSound.Play();
            }

        } else
        {
            if (customerSatIndex == 0 && customerSatisfaction > 0)
            {
                customerSatisfaction -= Time.deltaTime;
            }
            else if (customerSatIndex == 0 && customerSatisfaction <= 0)
            {
                customerSatIndex++;
                customerSatisfaction = 10;
                sighAngrily();
                getOurAnimalType2();
            }
            else if (customerSatIndex == 1 && customerSatisfaction > 0)
            {
                customerSatisfaction -= Time.deltaTime;
            }
            else if (customerSatIndex == 1 && customerSatisfaction <= 0)
            {
                customerSatIndex++;
                if(requestedDrug == "Strained Mash D" || requestedDrug == "Pink Syrup F" || requestedDrug == "Wormy Concotion")
                {
                    Debug.Log("I REQUEST A LIQUID SO I SHALL WAIT");
                    customerSatisfaction = 25;

                }
                else if(requestedDrug == "Blazing Brew")
                {
                    Debug.Log("I REQUEST THE BREW SO I SHALL WAIT");
                    customerSatisfaction = 35;
                }
                else
                {
                    customerSatisfaction = 10;
                }
                gruntAngrily();
                getOurAnimalType3();
            }
            else if (customerSatIndex == 2 && customerSatisfaction > 0)
            {
                customerSatisfaction -= Time.deltaTime;
            }
            else if (customerSatIndex == 2 && customerSatisfaction <= 0) // OUT OF TIME
            {
                customerSatIndex = 0;
                customerSatisfaction = 20;
                timeOut = true;
                timeOutMethod(timeOut);
            }

            /* Wander around aimlessly WHILE at pharma*/
            timeUntilWandering -= Time.deltaTime;
            if (timeUntilWandering <= 0)
            {
                xPos = Random.Range(-13, 16);
                zPos = Random.Range(-43, -35);
                transform.position = new Vector3(xPos, 1f, zPos);
                timeUntilWandering = Random.Range(15, 20);
            }
        }
    }
}
