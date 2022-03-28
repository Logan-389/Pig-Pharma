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

    public Text displayLives;
    int lives = 3;

    public void updateScore(string drugGiven)
    {
        score += 100;
        cash += 300;
        displayScore.text = score.ToString();
        displayCash.text = cash.ToString();
        if (lives == 2 || lives == 1)       /* You did good, here's some extra lives */
        {
            lives++;
            displayLives.text = lives.ToString();
        }
    }

    public void updateLives()
    {
        lives--;
        displayLives.text = lives.ToString();
        if (lives <= 0)
        {
            SceneManager.LoadScene("BusinessFail");
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
