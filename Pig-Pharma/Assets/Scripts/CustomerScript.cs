using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CustomerScript : MonoBehaviour
{
    public Text request;
    public Text displayScore;
    int rand;
    bool orderTaken = false;
    string requestedDrug;
    string drugGiven;
    int score = 0;

    public Text displayLives;
    int lives = 3;

    void OnMouseDown()
    {
        if(!orderTaken)
        {
            rand = Random.Range(0, 4);
            if (rand == 0)
            {
                request.text = "I want a... \ngreen pill";
                requestedDrug = "DrugBC";
            }
            else if (rand == 1)
            {
                request.text = "I want a... \npurple pill";
                requestedDrug = "DrugAB";
            }
            else if (rand == 2)
            {
                request.text = "I want a... \norange pill";
                requestedDrug = "DrugAC";
            }
            else if (rand == 3)
            {
                request.text = "I want... \ngreen strained \nmash";
                requestedDrug = "Strained Mash D";
            }
            else
            {
                request.text = "RAND FAILED";
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
                score+=100;
                displayScore.text = score.ToString();
                orderTaken = false;
                request.text = "I want a...";
                if(lives == 2 || lives == 1)
                {
                    lives++;
                    displayLives.text = lives.ToString();
                }
            } else
            {
                lives--;
                displayLives.text = lives.ToString();
                if (lives <= 0 )
                {
                    SceneManager.LoadScene("BusinessFail");
                }
                orderTaken = false;
                request.text = "I want a...";
            }
        }

}

    // Start is called before the first frame update
    void Start()
    {
        displayLives.text = lives.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
