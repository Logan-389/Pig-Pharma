using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDifficultyScript : MonoBehaviour
{

    string objectName = "";
    Ray ray;
    RaycastHit hit;
    bool hardMode = false;
    public GameObject DifficultyQuad;
    public GameObject InventoryCanvas;

    public bool returnDifficulty()
    {
        return hardMode;
    }

    // Start is called before the first frame update
    void Start()
    {
        DifficultyQuad.SetActive(true);
        InventoryCanvas.SetActive(false);
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit) && Input.GetMouseButtonDown(0))
        {
            objectName = hit.collider.name;
            if(objectName == "EasyButton")
            {
                Debug.Log("We are in easy mode");
                DifficultyQuad.SetActive(false);
                InventoryCanvas.SetActive(true);
                Time.timeScale = 1f;
            } else if(objectName == "HardButton")
            {
                hardMode = true;
                Debug.Log("We are in hard mode");
                DifficultyQuad.SetActive(false);
                InventoryCanvas.SetActive(true);
                Time.timeScale = 1f;
            }
        }
    }
}
