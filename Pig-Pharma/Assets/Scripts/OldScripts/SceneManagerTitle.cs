using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerTitle : MonoBehaviour
{

    public GameObject Quad2;
    public GameObject textInstructions;
    bool onePress = false;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp("space") && onePress == false)
        {
            onePress = true;
            Quad2.SetActive(false);
            textInstructions.SetActive(true);
        }
        if (Input.GetKeyDown("space") && onePress == true)
        {
            SceneManager.LoadScene("SampleScene");
        }
        if (Input.GetKeyDown("escape"))
        {
            Application.Quit();
        }
    }

    /*
    private void OnGUI()
    {
        if (GUI.Button(new Rect(((Screen.width) /3)-25, ((Screen.height) /2)+40, 200, 75), "Click"))
            //Rect = x, y, width, height
            SceneManager.LoadScene("SampleScene");
    }
    */  
}
