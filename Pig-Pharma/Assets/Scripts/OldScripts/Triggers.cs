using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Triggers : MonoBehaviour
{

    /* cat dialogue */
    //public GameObject Cat_Beginning_tr;
    public AudioSource sound1;
    public GameObject catDialogue1;
    public AudioSource sound2;
    public GameObject catDialogue2;
    public AudioSource sound3;
    public GameObject catDialogue3;
    public AudioSource sound4;
    public GameObject catDialogue4;
    public AudioSource sound5;
    public GameObject catDialogue5;
    public AudioSource sound6;
    public GameObject catDialogue6;
    public AudioSource sound7;
    public GameObject catDialogue7;

    /* puzzle 1 */
    public GameObject Bridge;
    public GameObject InvisWall_Lake;
    public GameObject CodeInputMenu;
    Animator animator_Bridge;

    /* monster */
    public GameObject tr_monster;
    public GameObject tr_monster2;
    public GameObject monster;
    public GameObject monster2;
    public GameObject Backgound_Audio;

    /* puzzle 2 */
    public GameObject Door_Left;
    Animator animator_Door_Left;
    public GameObject Door_Right;
    Animator animator_Door_Right;

    public GameObject GhostJumpScare;
    Animator animator_GhostJumpScare;
    public AudioSource JumpScareAudio;

    /* item UI */
    public GameObject InventoryUI;
    public GameObject seedIMG;
    public GameObject miracleGrowIMG;
    public GameObject bucketIMG;
    public GameObject waterBucketIMG;
    public GameObject MapA;
    public GameObject MapB;



    void Start()
    {
        animator_Bridge = Bridge.GetComponent<Animator>();
        animator_Door_Left = Door_Left.GetComponent<Animator>();
        animator_Door_Right = Door_Right.GetComponent<Animator>();
        animator_GhostJumpScare = GhostJumpScare.GetComponent<Animator>();
    }

    public void OnTriggerEnter(Collider col)
    {
        // Grab a referance to the triggered object's tag
        string tag = col.tag;

        // and compares it to the cases below.
        switch (tag)
        {
            
            case "CatBeginningDialogue":
                Debug.Log("Meow");
                sound1.Play();
                InventoryUI.SetActive(false);
                catDialogue1.SetActive(true);
                Time.timeScale = 0f;
                break;
            case "CatVineDialogue":
                Debug.Log("Meow");
                sound2.Play();
                InventoryUI.SetActive(false);
                catDialogue2.SetActive(true);
                Time.timeScale = 0f;
                break;
            case "CatLakeDialogue":
                Debug.Log("Meow");
                sound3.Play();
                InventoryUI.SetActive(false);
                catDialogue3.SetActive(true);
                Time.timeScale = 0f;
                break;
            case "CatExitDialogue":
                Debug.Log("Meow");
                sound4.Play();
                InventoryUI.SetActive(false);
                catDialogue4.SetActive(true);
                Time.timeScale = 0f;
                break;
            case "CatBridgeDialogue":
                Debug.Log("Meow");
                sound5.Play();
                InventoryUI.SetActive(false);
                catDialogue5.SetActive(true);
                Time.timeScale = 0f;
                break;
            case "CatHouseLeftDialogue":
                Debug.Log("Meow");
                sound6.Play();
                InventoryUI.SetActive(false);
                catDialogue6.SetActive(true);
                Time.timeScale = 0f;
                break;
            case "CatHouseRightDialogue":
                Debug.Log("Meow");
                sound7.Play();
                InventoryUI.SetActive(false);
                catDialogue7.SetActive(true);
                Time.timeScale = 0f;
                break;
            case "TriggerForDate":
                CodeInputMenu.SetActive(true);
                InventoryUI.SetActive(false);
                Time.timeScale = 0f;
                break;
            case "GhostJump_tr":
                animator_GhostJumpScare.SetTrigger("GhostJump_tr");
                JumpScareAudio.Play();
                break;

        }
    }

    public void OnTriggerStay(Collider col)
    {
        // Grab a referance to the triggered object's tag
        string tag = col.tag;

        // and compares it to the cases below.
        switch (tag)
        {
            case "BridgeAnimation":
                //Debug.Log("BridgeAnimation was triggered");
                animator_Bridge.SetTrigger("tr_bridge_anim");
                animator_Bridge.SetBool("bool_StandingByBridge", true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    animator_Bridge.SetBool("bool_bridge", true);
                    seedIMG.SetActive(false);
                    waterBucketIMG.SetActive(false);
                    miracleGrowIMG.SetActive(false);
                }
                break;
            case "GetSeed":
                animator_Bridge.SetTrigger("tr_getSeed");
                break;
            case "GetBucket":
                animator_Bridge.SetTrigger("tr_getBucket");
                InvisWall_Lake.SetActive(false);
                break;
            case "GetMiracleGrow":
                animator_Bridge.SetTrigger("tr_getMiracleGrow");
                break;
            case "GetWater":
                animator_Bridge.SetTrigger("tr_getWater");
                break;
            case "TurnOnMonster1":
                monster.SetActive(true);
                Backgound_Audio.SetActive(true);
                break;
            case "TurnOnMonster2":
                monster.SetActive(false);
                monster2.SetActive(true);
                MapA.SetActive(false);
                MapB.SetActive(true);
                break;
            case "BadEndTrigger":
                Debug.Log("You got the bad end.");
                SceneManager.LoadScene("BadEnd");
                break;
            case "BadEndTrigger2":
                Debug.Log("You got the bad end.");
                SceneManager.LoadScene("BadEnd");
                break;
            case "GoodEndTrigger":
                Debug.Log("You got the good end.");
                SceneManager.LoadScene("GoodEnd");
                break;
            case "DoorAnimation":
                Debug.Log("Door opened");
                animator_Door_Left.SetTrigger("tr_door_anim");
                animator_Door_Right.SetTrigger("tr_door_anim");
                animator_Door_Left.SetBool("bool_StandingByDoorLeft", true);
                animator_Door_Right.SetBool("bool_StandingByDoorRight", true);
                break;

        }
    }

    public void OnTriggerExit(Collider col)
    {

        // Grab a referance to the triggered object's tag
        string tag = col.tag;

        // and compares it to the cases below.
        switch (tag)
        {
            case "BridgeAnimation":
               // Debug.Log("BridgeAnimation was triggered (on exit)");
                animator_Bridge.SetTrigger("tr_bridge_anim");
                animator_Bridge.SetBool("bool_StandingByBridge", false);
                animator_Bridge.SetBool("bool_bridge", false);
                animator_Bridge.SetBool("bool_bridge", false);
                break;
            case "Door Animation":
                Debug.Log("Door opened");
                animator_Door_Left.SetTrigger("tr_door_anim");
                animator_Door_Right.SetTrigger("tr_door_anim");
                animator_Door_Left.SetBool("bool_StandingByDoorLeft", false);
                animator_Door_Right.SetBool("bool_StandingByDoorRight", false);
                break;
            case "CatBeginningDialogue":
                Debug.Log("Meow");
                catDialogue1.SetActive(false);
                break;
            case "CatVineDialogue":
                Debug.Log("Meow");
                catDialogue2.SetActive(false);
                break;
            case "CatLakeDialogue":
                Debug.Log("Meow");
                catDialogue3.SetActive(false);
                break;
            case "CatExitDialogue":
                Debug.Log("Meow");
                catDialogue4.SetActive(false);
                break;
            case "CatBridgeDialogue":
                Debug.Log("Meow");
                catDialogue5.SetActive(false);
                break;
            case "CatHouseLeftDialogue":
                Debug.Log("Meow");
                catDialogue6.SetActive(false);
                break;
            case "CatHouseRightDialogue":
                Debug.Log("Meow");
                catDialogue7.SetActive(false);
                break;
            case "TriggerForDate":
                CodeInputMenu.SetActive(false);
                InventoryUI.SetActive(true);
                break;

        }
    }
}
