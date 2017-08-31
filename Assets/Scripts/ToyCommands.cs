using UnityEngine;

public class ToyCommands : MonoBehaviour
{
   
    public Transform parentTransform;
    public MeshRenderer meshRenderer;


    public GameObject dog;
    public int toySpeed = 15;
    public enum ToyStates { StandByState, ReadyToThrowState, ThrowedState, CatchedState };
    public ToyStates ToyState { get; set; }

    private void Awake()
    {
        ToyState = ToyStates.StandByState;
    }
    void Start()
    {
       
    }

    private void Update()
    {/*
        switch (ToyState)
        {
            case ToyStates.StandByState:
                Debug.Log("StandByState: " + gameObject.name);
                break;
            case ToyStates.ReadyToThrowState:
                Debug.Log("ReadyToThrowState: " + gameObject.name);
                break;
            case ToyStates.ThrowedState:
                Debug.Log("ThrowedState: " + gameObject.name);
                break;
            case ToyStates.CatchedState:
                Debug.Log("CatchedState: " + gameObject.name);
                break;
            default:
                break;
        }*/
    }

    public static GameObject CurrentToy { get; set; }



    // Called by GazeGestureManager when the user performs a Select gesture
    void OnSelect()
    {
        CurrentToy = gameObject;
        Debug.Log("On Select: " + gameObject.name);
        // If the toy has no Rigidbody component, add one to enable physics.

        switch (ToyState)
        {
            case (ToyStates.CatchedState):
                {
                    SetToyFacingUser();

                }
                break;
            case (ToyStates.StandByState ): 
                {
                    SetToyFacingUser();
                    
                }
                break;
            case (ToyStates.ThrowedState):
                {
                    SetToyFacingUser();

                }
                break; 
            case ToyStates.ReadyToThrowState:
                {
                    //throw the toy
                    ThrowObject();
                    
                }
                break;
            default:
                {
                    Debug.Log("Default ball state");
                }
                break;
        }
    }

    /// <summary>
    /// Sets the camera transform as parent of the toy and put it in front of the user
    /// </summary>
    internal void SetToyFacingUser()
    {
        ToyState = ToyStates.ReadyToThrowState;
        meshRenderer.enabled = true;
        gameObject.transform.SetParent(Camera.main.transform);
        gameObject.transform.localPosition = new Vector3(0, 0, 1);
        Destroy(gameObject.GetComponent<Rigidbody>());
        
    }

    /// <summary>
    /// Resets the toy's parent
    /// </summary>
    internal void ThrowObject()
    {
        ToyState = ToyStates.ThrowedState;
        gameObject.transform.SetParent(parentTransform);
        var rigidbody = this.gameObject.AddComponent<Rigidbody>();
        rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
        rigidbody.drag = 1.5f;
        rigidbody.velocity = Camera.main.transform.forward * toySpeed;
        
    }

    void OnReset()
    {
        Debug.Log("OnReset");

        SetToyFacingUser();
    }

}
