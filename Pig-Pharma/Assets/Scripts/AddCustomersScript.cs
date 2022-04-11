using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddCustomersScript : MonoBehaviour
{

    /* Get difficulty setting */
    GameDifficultyScript difficultyScript;
    bool hardMode = false;
    bool customerCActive = false;
    public GameObject CustomerC;
    public GameObject CustomerD;
    float timeUntilNextCustomer;

    // Start is called before the first frame update
    void Start()
    {
        timeUntilNextCustomer = 120;
    }

    // Update is called once per frame
    void Update()
    {
        timeUntilNextCustomer -= Time.deltaTime;
        if(timeUntilNextCustomer <= 0)
        {
            difficultyScript = GameObject.FindGameObjectWithTag("Difficulty").GetComponent<GameDifficultyScript>();
            hardMode = difficultyScript.returnDifficulty();
            if (hardMode && !customerCActive)
            {
                customerCActive = true;
                CustomerC.SetActive(true);
                timeUntilNextCustomer = 180;
            }
            else if (hardMode && customerCActive)
            {
                CustomerD.SetActive(true);
            }
        }
    }
}
