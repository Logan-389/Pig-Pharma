using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UpdateScoreScript : MonoBehaviour
{
    public Text displayScore;
    int score = 0;
    public int cash = 500;
    public Text displayCash;

    int lives = 3;

    public GameObject heartImg1;
    public GameObject heartImg2;
    public GameObject heartImg3;

    /* Get difficulty setting */
    GameDifficultyScript difficultyScript;
    bool hardMode = false;

    public void updateScore(string drugGiven)
    {
        score += 100;
        cash += 300;
        displayScore.text = score.ToString();
        displayCash.text = cash.ToString();
        if (lives == 2 || lives == 1)       /* You did good, here's some extra lives */
        {
            lives++;
            updateLivesImage();
        }
    }

    public void updateLives()
    {
        lives--;
        updateLivesImage();
        if (lives <= 0)
        {
            SceneManager.LoadScene("BusinessFail");
        }
    }

    public void loseCash(string ingredientGrabbed)
    {
        
        cash -= 100;
        displayCash.text = cash.ToString();
    }

    public void farmerStealsCash()
    {
        difficultyScript = GameObject.FindGameObjectWithTag("Difficulty").GetComponent<GameDifficultyScript>();
        hardMode = difficultyScript.returnDifficulty();
        if(hardMode)
        {
            updateLives();
        }
        cash /= 2;
        displayCash.text = cash.ToString();
    }

    public void updateLivesImage()
    {
        if(lives == 3)
        {
            heartImg1.SetActive(true);
            heartImg2.SetActive(true);
            heartImg3.SetActive(true);
        } else if(lives == 2)
        {
            heartImg1.SetActive(true);
            heartImg2.SetActive(true);
            heartImg3.SetActive(false);
        } else if(lives == 1)
        {
            heartImg1.SetActive(true);
            heartImg2.SetActive(false);
            heartImg3.SetActive(false);
        } else
        {
            Debug.Log("Setting the heart live images failed");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      if(cash < -500)
        {
            Debug.Log("LOSE CASH");
            SceneManager.LoadScene("BusinessFail");
        }
    }
}
