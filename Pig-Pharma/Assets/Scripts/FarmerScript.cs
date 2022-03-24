using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FarmerScript : MonoBehaviour
{

    string objectName = "";
    Ray ray;
    RaycastHit hit;
    private bool pigIsBeingAPig = false;


    public GameObject Farmer;
    public float timeRemaining = 5;
    private int farmerStateIndex = 0;


    /* Farmer Visuals */
    Renderer farmerRenderer;
    public Texture FarmerNormImg;
    public Texture FarmerAngryImg;
    

    // Start is called before the first frame update
    void Start()
    {
        farmerRenderer = Farmer.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        /* Pig interaction */
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit) && Input.GetMouseButtonDown(0))
        {
            objectName = hit.collider.name;
            if (objectName == "Pig" && !pigIsBeingAPig)
            {
                Debug.Log("You have selected THE PIG");
                pigIsBeingAPig = true;
            }
            else if (objectName == "Pig" && pigIsBeingAPig)
            {
                Debug.Log("You have selected THE PIG WORK MODE");
                pigIsBeingAPig = false;
            }
        }


        /* The farmer has a timer for when he appears */
        if (timeRemaining > 0) //Running down the clock
        {
            timeRemaining -= Time.deltaTime;
        } else if(timeRemaining <= 0 && farmerStateIndex == 0) //Out of time 0
        {
            timeRemaining = Random.Range(5.0f, 10.0f);
            farmerStateIndex++;
        } else if (timeRemaining <= 0 && farmerStateIndex == 1) //Out of time 1
        {
            timeRemaining = 3;  
            farmerStateIndex++;
        }
        else if (timeRemaining <= 0 && farmerStateIndex == 2) //Out of time 2
        {
            timeRemaining = Random.Range(30.0f, 60.0f);
            farmerStateIndex = 0; /* Reset Farmer State Index */

            if(!pigIsBeingAPig)
            {
                Debug.Log("You're not acting like a pig right now!!!");
                SceneManager.LoadScene("BusinessFail"); /* your pig drugs days are over */
            }

        }

        /* Move the farmer into position */
        if (farmerStateIndex == 0)
        {
            /* Chilling off screen */
            transform.position = new Vector3(-70.5f, -0.4f, 32.4f);
            farmerRenderer.material.SetTexture("_MainTex", FarmerNormImg);

        } else if(farmerStateIndex == 1)
        {
            /* Hiding behind hay bales*/
            transform.position = new Vector3(-12.5f, -0.4f, 32.4f);
        }
        else if(farmerStateIndex == 2)
        {
            /* Getting ready to grab pig */
            transform.position = new Vector3(5.1f, -0.4f, 32.4f);
            farmerRenderer.material.SetTexture("_MainTex", FarmerAngryImg);
        }


    }
}
