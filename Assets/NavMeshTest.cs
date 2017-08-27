using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NavMeshTest : MonoBehaviour
{
    public Transform target;
    public GameObject currentToy;

    Vector3 destination;
    NavMeshAgent agent;

    void Start()
    {
        // Cache agent component and destination
        agent = GetComponent<NavMeshAgent>();
        destination = agent.destination;
    }

    

    void FixedUpdate()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            target = currentToy.transform;
        }
        // Update destination if the target moves one unit
        if (target != null && Vector3.Distance(destination, target.position) > 1.0f )
        {
            agent.destination = target.position;
        }

        // The toy is catched
        if (target != null && Vector3.Distance(agent.transform.position, target.position) < 1)
        {

            target = Camera.main.transform;


        }

        // The dog has brought the toy
        if (Vector3.Distance(agent.transform.position, Camera.main.transform.position) < 1.5f)
        {

            agent.destination = agent.transform.position;
           
        }
    }


 }

