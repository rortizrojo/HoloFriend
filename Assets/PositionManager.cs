using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionManager : MonoBehaviour {

    Transform parentrTransform;

    // Use this for initialization
    void Start () {

        parentrTransform = gameObject.GetComponentInParent<Transform>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    internal void SetPosition(float x, float y, float z)
    {
        gameObject.transform.SetParent(parentrTransform);
        gameObject.transform.position = new Vector3(x, y, z);
        Destroy(gameObject.GetComponent<Rigidbody>());

    }
}
