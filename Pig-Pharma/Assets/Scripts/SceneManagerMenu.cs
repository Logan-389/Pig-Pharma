using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerMenu : MonoBehaviour
{

    string objectName = "";
    Ray ray;
    RaycastHit hit;
    public GameObject CreditsQuad;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit) && Input.GetMouseButtonDown(0))
        {
            objectName = hit.collider.name;
            if (objectName == "StartButton")
            {
                SceneManager.LoadScene("SampleScene");
            } 
            else if (objectName == "CreditsButton")
            {
                CreditsQuad.SetActive(true);
            }
            else if (objectName == "CloseCreditsButton")
            {
                CreditsQuad.SetActive(false);
            }
            else if(objectName == "QuitButton")
            {
                Application.Quit();
            }

        }
    }
}
