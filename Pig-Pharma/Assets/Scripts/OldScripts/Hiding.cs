using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hiding : MonoBehaviour
{

    MonsterAI[] monsters;
    
    void Start()
    {
        monsters = FindObjectsOfType<MonsterAI>(true);
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HidingSpot"))
        {
            Debug.Log("Entered Hiding Spot");
            foreach (var monster in monsters)
            {
                if (monster.isActiveAndEnabled)
                {
                    monster.StopHuntCycle();
                }
            }
        }
    }


    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("HidingSpot"))
        {
            foreach (var monster in monsters)
            {
                Debug.Log("Left Hiding Spot");
                if (monster.isActiveAndEnabled)
                {
                    monster.StartHuntCycle();
                }
            }
        }
    }


}
