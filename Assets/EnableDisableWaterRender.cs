using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableDisableWaterRender : MonoBehaviour {

    public MeshRenderer parentMesh;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.GetComponent<MeshRenderer>().enabled = parentMesh.enabled;

    }
}
