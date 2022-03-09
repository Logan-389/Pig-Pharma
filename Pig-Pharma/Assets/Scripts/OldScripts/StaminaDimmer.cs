using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaDimmer : MonoBehaviour
{
    public FP_ControllerMovement character;


    new Light light;

    float initialIntensity;



    void Start()
    {
        light = GetComponent<Light>();

        initialIntensity = light.intensity;

    }

    void Update() {
        if (character.canRun)
        {
            light.intensity = character.sprintTimer / character.sprintTimeLimit * initialIntensity;
        }
        else if (character.sprintTimer >= Mathf.Max(0, character.sprintTimeLimit - 2))
        {
            light.intensity = (1 - (character.sprintTimeLimit - character.sprintTimer) / 2) * initialIntensity;
        }
        Debug.Log(light.intensity);
    }


}
