using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableDisable : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.A))
        {
            LocalNavMeshBuilder localNavMesh = GetComponent<LocalNavMeshBuilder>();
            localNavMesh.enabled = false;
            localNavMesh.enabled = true;
        }
	}
}
