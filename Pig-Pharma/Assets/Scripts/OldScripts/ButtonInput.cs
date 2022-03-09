using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInput : MonoBehaviour
{

    //public GameObject Bridge;
    // Animator animator_Bridge;

    public GameObject Player_Sprite;
    Animator animator_Walk_Anim_0;

    void Start()
    {

        //animator_Bridge = Bridge.GetComponent<Animator>();
        animator_Walk_Anim_0 = Player_Sprite.GetComponent<Animator>();

    }

    void Update()
    {
        if (Input.GetKey("w") || (Input.GetKey(KeyCode.UpArrow)))
        {
            animator_Walk_Anim_0.Play("Walk_Back");
        }
        else if (Input.GetKey("a") || (Input.GetKey(KeyCode.LeftArrow)))
        {
            animator_Walk_Anim_0.Play("Walk_Left");
        }
        else if (Input.GetKey("s") || (Input.GetKey(KeyCode.DownArrow)))
        {
            animator_Walk_Anim_0.Play("Walk_Front");
        }
        else if (Input.GetKey("d") || (Input.GetKey(KeyCode.RightArrow)))
        {
            animator_Walk_Anim_0.Play("Walk_Right");
        }


        if (Input.GetKeyUp("w") || (Input.GetKeyUp(KeyCode.UpArrow)))
        {
            animator_Walk_Anim_0.Play("Still_Back");
        }
        else if (Input.GetKeyUp("a") || (Input.GetKeyUp(KeyCode.LeftArrow)))
        {
            animator_Walk_Anim_0.Play("Still_Left");
        }
        else if (Input.GetKeyUp("s") || (Input.GetKeyUp(KeyCode.DownArrow)))
        {
            animator_Walk_Anim_0.Play("Still_Front");
        }
        else if (Input.GetKeyUp("d") || (Input.GetKeyUp(KeyCode.RightArrow)))
        {
            animator_Walk_Anim_0.Play("Still_Right");
        }

    }
}

