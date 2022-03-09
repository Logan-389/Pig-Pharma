using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Inventory : MonoBehaviour
{
    static HashSet<string> items = new HashSet<string>();

    Item itemToPickUp;

    public GameObject seedIMG;
    public GameObject miracleGrowIMG;
    public GameObject bucketIMG;
    public GameObject waterBucketIMG;
    public bool press, seedBool, bucketBool, waterBool, miracleBool;



    void Update()
    {
        if (itemToPickUp != null && Input.GetKeyDown(KeyCode.E))
        {
            items.Add(itemToPickUp.id);
            Destroy(itemToPickUp.gameObject);
            itemToPickUp = null;
            press = true;
            Debug.Log("Press: " + press);
        }

        if (press && seedBool)
        {
            seedIMG.SetActive(true);
            press = false;
            seedBool = false;
        }
        else if (press && waterBool)
        {
            bucketIMG.SetActive(false);
            waterBucketIMG.SetActive(true);
            press = false;
            waterBool = false;
        }
        else if (press && bucketBool)
        {
            bucketIMG.SetActive(true);
            press = false;
            bucketBool = false;
        }
        else if (press && miracleBool)
        {
            miracleGrowIMG.SetActive(true);
            press = false;
            miracleBool = false;
        }


    }

    void OnTriggerEnter(Collider collider)
    {

        string tag = collider.tag;
        switch (tag)
        {
            case "GetSeed":
                seedBool = true;
                break;
            case "GetBucket":
                bucketBool = true;
                break;
            case "GetMiracleGrow":
                miracleBool = true;
                break;
            case "GetWater":
                waterBool = true;
                break;
        }
        itemToPickUp = collider.GetComponent<Item>();
    }

    void OnTriggerExit(Collider collider)
    {
        var item = collider.GetComponent<Item>();
        if (item != null)
        {
            itemToPickUp = null;
        }
    }



}
