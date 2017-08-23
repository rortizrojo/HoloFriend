using UnityEngine;

public class ToyCommands : MonoBehaviour
{
    private static GameObject currentToy;
    public Transform parentTransform;
    public MeshRenderer meshRenderer;


    public GameObject dog;
    public int toySpeed = 15;
    public enum ToyStates { StandByState, ReadyToThrowState, ThrowedState, CatchedState };
    public ToyStates toyState;
    

    void Start()
    {
        toyState = ToyStates.StandByState;
    }

    private void Update()
    {/*
        switch (toyState)
        {
            case ToyStates.StandByState:
                Debug.Log("StandByState" );
                break;
            case ToyStates.ReadyToThrowState:
                Debug.Log("ReadyToThrowState");
                break;
            case ToyStates.ThrowedState:
                Debug.Log("ThrowedState");
                break;
            case ToyStates.CatchedState:
                Debug.Log("CatchedState");
                break;
            default:
                break;
        }*/
    }

    public static GameObject GetCurrentToy()
    {
        return currentToy;
    }


    // Called by GazeGestureManager when the user performs a Select gesture
    void OnSelect()
    {
        currentToy = gameObject;
        Debug.Log("On Select: " + gameObject.name);
        // If the toy has no Rigidbody component, add one to enable physics.

        switch (toyState)
        {
            case ToyStates.StandByState: 
                {
                    SetToyFacingUser();
                    
                }
                break;
            case ToyStates.ReadyToThrowState:
                {
                    //throw the toy
                    ResetToyParent();
                    toyState = ToyStates.ThrowedState;
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
        meshRenderer.enabled = true;
        gameObject.transform.SetParent(Camera.main.transform);
        gameObject.transform.localPosition = new Vector3(0, 0, 1);
        Destroy(gameObject.GetComponent<Rigidbody>());
        toyState = ToyStates.ReadyToThrowState;
    }

    /// <summary>
    /// Resets the toy's parent
    /// </summary>
    internal void ResetToyParent()
    {
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
