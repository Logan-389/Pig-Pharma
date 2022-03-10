using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerBusinessFail : MonoBehaviour
{

    string objectName = "";
    Ray ray;
    RaycastHit hit;

    private void Start()
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
            if(objectName == "FailButton")
            {
                SceneManager.LoadScene("SampleScene");
            }

        }
        if (Input.GetKeyDown("escape"))
        {
            Application.Quit();
        }
    }
}

