using System;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent (typeof (NavMeshAgent))]
public class FollowTarget : MonoBehaviour {

    
	void FixedUpdate () {
        /*  REVISAR ESTO*/
        /*
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


            stateManager.IsEating = Vector3.Distance(agent.transform.position, target.position) < 1f && 
                                    stateManager.isHungry;
            
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
                TakeObject();
                target = Camera.main.transform;

            }

            // The dog has brought the toy
            if (Distance( agent.transform.position ,Camera.main.transform.position) < 1f &&
                 (currentToy.GetComponent<ToyCommands>().toyState == ToyCommands.ToyStates.CatchedState))
            {
                // Debug.Log("The dog has brought.  " );

                LeaveObject();

                agent.destination = agent.transform.position;
                currentToy.GetComponent<ToyCommands>().toyState = ToyCommands.ToyStates.StandByState;
                stateManager.IsMoving = false;
            }
        }

    */


     
    }














    

}