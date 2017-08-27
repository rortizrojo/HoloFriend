using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasScript : MonoBehaviour {
    
    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnResetCanvas()
    {
        Debug.Log("Reset Canvas: " );
        transform.localPosition = Camera.main.transform.position + new Vector3(0, 0, 1);
        transform.localRotation = Camera.main.transform.rotation;


    }

}
