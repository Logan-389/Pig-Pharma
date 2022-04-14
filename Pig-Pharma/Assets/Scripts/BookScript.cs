using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookScript : MonoBehaviour
{

    public GameObject InventoryCanvas;
    public GameObject BookPages;
    private bool bookIsOpen = false;
    int pageIndex;
    int totalPages = 4;

    string objectName = "";
    Ray ray;
    RaycastHit hit;

    public GameObject BookPageQuad1;
    Renderer bookRenderer;
    public Texture BookPage1;
    public Texture BookPage2;
    public Texture BookPage3;
    public Texture BookPage4;
    public Texture BookPage5;

    // Start is called before the first frame update
    void Start()
    {
        bookRenderer = BookPageQuad1.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {


        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit) && Input.GetMouseButtonDown(0))
        {
            objectName = hit.collider.name;
            Debug.Log(objectName);
            if (objectName == "Book" && !bookIsOpen)
            {
                BookPages.SetActive(true);
                InventoryCanvas.SetActive(false);
                bookIsOpen = true;
            } else if(objectName == "Book" && bookIsOpen || objectName == "BookCloseButton")
            {
                pageIndex = 0;
                BookPages.SetActive(false);
                InventoryCanvas.SetActive(true);
                bookIsOpen = false;
            } else if(objectName == "ToLeftButton" && pageIndex != 0)
            {
                pageIndex--;
            } else if(objectName == "ToRightButton" && pageIndex != totalPages)
            {
                pageIndex++;
            }

            if(pageIndex == 0)
            {
                bookRenderer.material.SetTexture("_MainTex",BookPage1);
            } 
            else if(pageIndex == 1)
            {
                bookRenderer.material.SetTexture("_MainTex", BookPage2);
            }
            else if (pageIndex == 2)
            {
                bookRenderer.material.SetTexture("_MainTex", BookPage3);
            }
            else if (pageIndex == 3)
            {
                bookRenderer.material.SetTexture("_MainTex", BookPage4);
            }
            else if (pageIndex == 4)
            {
                bookRenderer.material.SetTexture("_MainTex", BookPage5);
            }
        }
    }
}
