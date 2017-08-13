using UnityEngine;

public class BoneCommands : MonoBehaviour
{
    public GameObject dog;
    public int boneSpeed = 15;
    public bool isCatching { get; set; }
    public bool isReadyToThrow { get; set; }

    void Start()
    {
        isReadyToThrow = false;
        isCatching = false;
    }


    // Called by GazeGestureManager when the user performs a Select gesture
    void OnSelect()
    {

        Debug.Log("Onselect: ");
        // If the sphere has no Rigidbody component, add one to enable physics.
        if (!this.GetComponent<Rigidbody>())
        {
            var rigidbody = this.gameObject.AddComponent<Rigidbody>();
            rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
            rigidbody.drag = 1.5f;
            rigidbody.velocity = Camera.main.transform.forward * boneSpeed;
            isCatching = true;
            dog.GetComponent<FollowTarget>().setBallTarget();

        }
        else
        {


            if (!isReadyToThrow)
            {
                isReadyToThrow = true;
                dog.GetComponent<FollowTarget>().resetBallPosition();

            }
            else
            {
                dog.GetComponent<FollowTarget>().setBallTarget();
                Rigidbody rigidbody = this.GetComponent<Rigidbody>();
                rigidbody.velocity = Camera.main.transform.forward * boneSpeed;
                isCatching = true;
                isReadyToThrow = false;
            }

        }
    }


}
