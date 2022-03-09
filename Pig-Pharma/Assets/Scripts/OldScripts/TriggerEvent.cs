using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEvent : MonoBehaviour
{
    
    public UnityEvent action;
    
    
    void OnTriggerEnter(Collider collider) {
        if (collider.CompareTag("Player")) {
            action.Invoke();
        }
    }

}
