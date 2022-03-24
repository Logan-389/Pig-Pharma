using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{

    public Camera cam;
    Ray ray;
    RaycastHit hit;
    public NavMeshAgent agent;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            ray = cam.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit))
            {
                /* Move out agent */
                agent.SetDestination(hit.point);
            }
        }
    }
}
