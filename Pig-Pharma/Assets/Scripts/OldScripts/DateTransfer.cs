using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DateTransfer : MonoBehaviour
{
    public string theDate;
    public GameObject inputField;
    public GameObject textDisplay;
    public string theCorrectDate;
    public string theCorrectDate2;

    public static bool GameIsPausedCode = false;

    public GameObject codeEnterMenuUI;

    public GameObject InvisWall2;

    // Update is called once per frame
    void Update()
    {

        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (GameIsPausedCode)
            {
                ResumeCode();
            }
            else
            {
                PauseCode();
            }
        }
        */
    }
     void ResumeCode()
    {
        codeEnterMenuUI.SetActive(false);
        //Time.timeScale = 1f;
        GameIsPausedCode = false;
    }

    void PauseCode()
    {
        codeEnterMenuUI.SetActive(true);
        //Time.timeScale = 0f;
        GameIsPausedCode = true;
    }

    public void ExitMenu()
    {
        codeEnterMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPausedCode = false;
    }

    public void StoreDate()
    {
        theCorrectDate = "0427";
        theCorrectDate2 = "04/27";
        theDate = inputField.GetComponent<Text>().text;
        if (theDate.Equals(theCorrectDate) || theDate.Equals(theCorrectDate2))
        {
            textDisplay.GetComponent<Text>().text = "The date " + theDate + " is correct!";
            InvisWall2.SetActive(false);
            codeEnterMenuUI.SetActive(false);
            Time.timeScale = 1f;
        } else
        {
            textDisplay.GetComponent<Text>().text = theDate + " doesn't seem right...";
        }
        
    }
}
