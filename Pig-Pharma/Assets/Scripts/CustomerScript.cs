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

    /* Audio */
    public AudioSource enterSound;
    public AudioSource bellSound;

    void OnMouseDown()
    {
        if(!orderTaken)
        {
            rand = Random.Range(0, 5);
            if (rand == 0)
            {
                requestA.SetText("I want a... \ngreen pill");
                requestedDrug = "DrugBC";
            }
            else if (rand == 1)
            {
                requestA.SetText("I want a... \npurple pill");
                requestedDrug = "DrugAB";
            }
            else if (rand == 2)
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
                requestA.SetText("I want a...\nPink Syrup F \nmash");
                requestedDrug = "Pink Syrup F";
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
            customerRenderer.material.SetTexture("_MainTex", CustomerHappyImg); 
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
       

    // Start is called before the first frame update
    void Start()
    {
        customerRenderer = Customer.GetComponent<Renderer>();
        transform.position = new Vector3(8.8f, 1f, -72f);
        timeTilAtPharma = Random.Range(3, 25);
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
                float xPos = Random.Range(-16, 15);
                float zPos = Random.Range(-32, -19);
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
                customerRenderer.material.SetTexture("_MainTex", CustomerNeutralImg);
            }
            else if (customerSatIndex == 1 && customerSatisfaction > 0)
            {
                customerSatisfaction -= Time.deltaTime;
            }
            else if (customerSatIndex == 1 && customerSatisfaction <= 0)
            {
                customerSatIndex++;
                if(requestedDrug == "Strained Mash D" || requestedDrug == "Pink Syrup F")
                {
                    customerSatisfaction = 20;
                } else
                {
                    customerSatisfaction = 10;
                }    
                customerRenderer.material.SetTexture("_MainTex", CustomerMadImg);
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
        }
    }
}
