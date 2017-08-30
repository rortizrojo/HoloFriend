using UnityEngine;
using UnityEngine.AI;

[RequireComponent (typeof (NavMeshAgent))]
public class FollowTarget : MonoBehaviour {
	Transform target;
    public Transform mouth;
    public GameObject objectsGameObject;
    GameObject currentToy;
    public GameObject waterBowl;
    public GameObject foodBowl;
    private StateManager stateManager;
        
    Vector3 destination;
	NavMeshAgent agent;

    void Start () {
        // Cache agent component and destination
        agent = GetComponent<NavMeshAgent>();
		destination = agent.destination;
        stateManager = gameObject.GetComponent<StateManager>();
    }

	void FixedUpdate () {
        /*  REVISAR ESTO*/
        if( stateManager.currentState == stateManager.angryState &&
                (waterBowl.GetComponent<PositionManager>().IsPlaced ||
                 foodBowl.GetComponent<PositionManager>().IsPlaced
                 )
        )
        {
            if (waterBowl.GetComponent<PositionManager>().IsPlaced)
            {
                agent.destination = waterBowl.transform.position;

            }
            else
            {
                agent.destination = foodBowl.transform.position;
            }

            stateManager.IsMoving = true;


            stateManager.IsEating = Vector3.Distance(agent.transform.position, target.position) < 1f && stateManager.isHungry;
            
        }




        currentToy = ToyCommands.GetCurrentToy();
        

        if (currentToy != null){
            

            if (currentToy.GetComponent<ToyCommands>().toyState == ToyCommands.ToyStates.ThrowedState)
            {
                target = currentToy.transform;
            }


            // Update destination if the target moves one unit
            if (target != null && Vector3.Distance(destination, target.position) > 1.0f && 
                currentToy.GetComponent<ToyCommands>().toyState == ToyCommands.ToyStates.ThrowedState ||
                currentToy.GetComponent<ToyCommands>().toyState == ToyCommands.ToyStates.CatchedState)
            {
                //Debug.Log("Update destination");
                agent.destination = target.position;
                stateManager.IsMoving = true;
            }
            
            // The toy is catched
            if (target != null && Vector3.Distance(agent.transform.position, target.position) < 1 &&
                Vector3.Distance(Camera.main.transform.position, target.position) > 3.5f &&
                (currentToy.GetComponent<ToyCommands>().toyState == ToyCommands.ToyStates.ThrowedState))
            {
                //Debug.Log("The toy is catched");
                currentToy.GetComponent<ToyCommands>().toyState = ToyCommands.ToyStates.CatchedState;
                currentToy.transform.SetParent(mouth);
                currentToy.transform.localPosition = new Vector3(-1.418f, 0, -0.316f);
                Destroy(currentToy.GetComponent<Rigidbody>());
                target = Camera.main.transform;

            }

            // The dog has brought the toy
            if (Distance( agent.transform.position ,Camera.main.transform.position) < 1f &&
                 (currentToy.GetComponent<ToyCommands>().toyState == ToyCommands.ToyStates.CatchedState))
            {
               // Debug.Log("The dog has brought.  " );

                currentToy.transform.SetParent(objectsGameObject.transform);
                var rigidbody = currentToy.AddComponent<Rigidbody>();
                rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
                rigidbody.drag = 1.5f;
                agent.destination = agent.transform.position;
                currentToy.GetComponent<ToyCommands>().toyState = ToyCommands.ToyStates.StandByState;
                stateManager.IsMoving = false;
            }
        }




    }


    float Distance(Vector3 pos1, Vector3 pos2)
    {
        return Mathf.Sqrt(Mathf.Pow(Mathf.Abs(pos1.x - pos2.x), 2) + Mathf.Pow(Mathf.Abs(pos1.z - pos2.z), 2));
    }


    

}