using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

[RequireComponent (typeof (NavMeshAgent))]
public class FollowTarget : MonoBehaviour {
	public Transform target;
    public Transform userPosition;
    public Transform mouth;
    public GameObject objectsGameObject;
    public GameObject ballGameObject;
    public SkinnedMeshRenderer DogMesh;
    public IState currentState;
    public IState angryState;
    public IState happyState;
    public IState sadState;
    public IState tiredState;

    Vector3 destination;
	NavMeshAgent agent;
    private bool isBallCatched;

    // Minimum = 0 ; Maximum = 100
    public float hungry;
    public float energy;
    public float interaction;

    public Image imageHungry;
    public Image imageEnergy;
    public Image imageInteraction;

    void Start () {

        hungry = 50;
        energy = 50;
        interaction = 50;
        
        // Cache agent component and destination
        agent = GetComponent<NavMeshAgent>();
		destination = agent.destination;

        isBallCatched = false;
        tiredState = new TiredState();
        angryState = new AngryState();
        sadState = new SadState();
        happyState = new HappyState();


    }

	void FixedUpdate () {

        hungry -= 0.008f;
        energy -= 0.008f;
        interaction -= 0.008f;

        imageHungry.fillAmount = hungry / 100;
        imageEnergy.fillAmount = energy / 100;
        imageInteraction.fillAmount = interaction / 100;

        UpdateState();


        if (currentState != null)
            currentState.UpdateAnims(DogMesh);

        // Update destination if the target moves one unit
        if (Vector3.Distance(destination, target.position) > 1.0f && ballGameObject.GetComponent<SphereCommands>().isCatching)
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
            ballGameObject.GetComponent<SphereCommands>().isCatching = false;
        }

    }


    internal void UpdateState()
    {

        if (hungry < 25) // Angry 
        {
            currentState = angryState;
            Debug.Log("Angry");
        }
        else if (interaction < 25) // Sad
        {
            currentState = sadState;
            Debug.Log("Sad");
        }
        else if (energy < 25) // Tired{
        {
            currentState = tiredState;
            Debug.Log("Tired");
        }
        else  // Happy{
        {
            currentState = happyState;
            Debug.Log("Happy");
        }
    }

    internal void resetBallPosition()
    {
        ballGameObject.transform.SetParent(Camera.main.transform);
        ballGameObject.transform.localPosition = new Vector3(0, 0, 1);
        Destroy(ballGameObject.GetComponent<Rigidbody>());

    }

    internal void setBallTarget()
    {
        target = ballGameObject.transform;
        ballGameObject.transform.SetParent(objectsGameObject.transform);
    }
}