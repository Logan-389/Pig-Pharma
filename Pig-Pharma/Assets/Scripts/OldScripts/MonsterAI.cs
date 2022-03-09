using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterAI : MonoBehaviour
{
    

    NavMeshAgent agent;

    GameObject player;

    public Transform homePoint;

    private bool hunting;

    IEnumerator activeHuntCycle = null;
    IEnumerator activeWanderCycle = null;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player");
        StartHuntCycle();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (hunting == true)
        {
            agent.destination = player.transform.position;
        }

    }

    void OnDisable() {
        StopAllCoroutines();
    }

    IEnumerator HuntCycle()
    {
        while (true)
        {
            hunting = false;
            agent.destination = homePoint.position;
            yield return new WaitForSeconds(Random.Range(10, 60));
            hunting = true;
            yield return new WaitForSeconds(Random.Range(10, 180));
        }
    }

    IEnumerator WanderCycle()
    {
        const float radius = 1.5f;
        hunting = false;
        var wanderOrigin = player.transform.position;
        Debug.Log("Wandering around " + wanderOrigin);
        for (int i = 0; i < 4; i++)
        {
            
            agent.destination = wanderOrigin + new Vector3(Random.Range(-radius, radius), 0, Random.Range(-radius, radius));

            yield return new WaitForSeconds(4);
        }

        agent.destination = homePoint.position;



    }


    public void StartHuntCycle()
    {
        Debug.Log("Starting Hunt Cycle");
        activeHuntCycle = HuntCycle();
        StartCoroutine(activeHuntCycle);
        if (activeWanderCycle != null)
        {
            StopCoroutine(activeWanderCycle);
            hunting = true;
        }
        activeWanderCycle = null;
    }

    public void StopHuntCycle()
    {
        Debug.Log("Stoping Hunt Cycle");
        if (activeHuntCycle != null)
        {
            StopCoroutine(activeHuntCycle);
            if (hunting)
            {
                activeWanderCycle = WanderCycle();
                StartCoroutine(activeWanderCycle);
            }
        }
        activeHuntCycle = null;
        hunting = false;
        agent.destination = homePoint.position;
    }

}
