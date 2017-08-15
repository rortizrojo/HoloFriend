using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

[RequireComponent (typeof (NavMeshAgent))]
public class FollowTarget : MonoBehaviour {
	Transform target;
    public Transform mouth;
    public GameObject objectsGameObject;
    GameObject currentToy;
    public GameObject waterBowl;
    public GameObject foodBowl;
    
    Vector3 destination;
	NavMeshAgent agent;
    

    void Start () {

        // Cache agent component and destination
        agent = GetComponent<NavMeshAgent>();
		destination = agent.destination;

    }

	void FixedUpdate () {
        

        currentToy = ToyCommands.GetCurrentToy();
       

        if (currentToy != null){
            

            if (currentToy.GetComponent<ToyCommands>().toyState == ToyCommands.ToyStates.ThrowedState)
            {
                target = currentToy.transform;
            }


            // Update destination if the target moves one unit
            if (Vector3.Distance(destination, target.position) > 1.0f && 
                currentToy.GetComponent<ToyCommands>().toyState == ToyCommands.ToyStates.ThrowedState ||
                currentToy.GetComponent<ToyCommands>().toyState == ToyCommands.ToyStates.CatchedState)
            {
                agent.destination = target.position;
            }
            
            // The toy is catched
            if (Vector3.Distance(agent.transform.position, target.position) < 1 &&
                (currentToy.GetComponent<ToyCommands>().toyState == ToyCommands.ToyStates.ThrowedState))
            {
                currentToy.GetComponent<ToyCommands>().toyState = ToyCommands.ToyStates.CatchedState;
                currentToy.transform.SetParent(mouth);
                currentToy.transform.localPosition = new Vector3(-1.418f, 0, -0.316f);
                Destroy(currentToy.GetComponent<Rigidbody>());
                target = Camera.main.transform;


            }

            // The dog has brought the toy
            if (Vector3.Distance(agent.transform.position, Camera.main.transform.position) < 1.5f &&
                 (currentToy.GetComponent<ToyCommands>().toyState == ToyCommands.ToyStates.CatchedState))
            {
                currentToy.transform.SetParent(objectsGameObject.transform);
                var rigidbody = currentToy.AddComponent<Rigidbody>();
                rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
                rigidbody.drag = 1.5f;
                agent.destination = agent.transform.position;
                currentToy.GetComponent<ToyCommands>().toyState = ToyCommands.ToyStates.StandByState;
            }
        }


    }


    

}