using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HappyState : IState
{



    public void ejecutar(GameObject avatar)
    {


        //Debug.Log("Happy: ");
        /*
        // Update destination if the target moves one unit
        if (Vector3.Distance(destination, target.position) > 1.0f && SphereCommands.getInstance().isCatching)
        {
            destination = target.position;
            agent.destination = destination;
        }

        // The ball is catched
        if (Vector3.Distance(agent.transform.position, target.position) < 1 && !isBallCatched)
        {
            isBallCatched = true;
            ballGameObject.transform.SetParent(mouth);
            ballGameObject.transform.localPosition = new Vector3(0, 0, 0);
            Destroy(ballGameObject.GetComponent<Rigidbody>());
            target = Camera.main.transform;


        }

        // The dog has brought the ball
        if (Vector3.Distance(agent.transform.position, Camera.main.transform.position) < 1.5f && isBallCatched)
        {
            ballGameObject.transform.SetParent(objectsGameObject.transform);
            var rigidbody = ballGameObject.AddComponent<Rigidbody>();
            rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
            rigidbody.drag = 1.5f;
            agent.destination = agent.transform.position;
            isBallCatched = false;
            SphereCommands.getInstance().isCatching = false;
        }*/
    }


    public void UpdateAnims(GameObject gameObject, GameObject avatar, Animator animator, float hungry, float energy, float interaction)
    {
        animator.SetFloat("Energy", energy);

        animator.SetBool("isMoving", gameObject.GetComponent<FollowTarget>().isMoving);
    
    }
}
